using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSharpCourse.MerchandiseApi.Application.Commands;
using CSharpCourse.MerchandiseApi.Domain.AggregationModels.MerchandiseRequestAggregate;
using CSharpCourse.MerchandiseApi.Domain.AggregationModels.SkuPresetAggregate;
using MediatR;

namespace CSharpCourse.MerchandiseApi.Application.Handlers
{
    public class GiveOutMerchandiseCommandHandler : IRequestHandler<GiveOutMerchandiseCommand>
    {
        private readonly IMerchandiseRepository _merchandiseRepository;
        private readonly ISkuPresetRepository _skuPresetRepository;

        public GiveOutMerchandiseCommandHandler(IMerchandiseRepository merchandiseRepository, ISkuPresetRepository skuPresetRepository)
        {
            _skuPresetRepository = skuPresetRepository;
            _merchandiseRepository = merchandiseRepository;
        }

        public async Task<Unit> Handle(GiveOutMerchandiseCommand request, CancellationToken cancellationToken)
        {
            // Поиск пресета по названию
            var preset = await _skuPresetRepository.GetByPresetType(new PresetType(0, request.Type), cancellationToken);

            // получение списка запросов для пользователя по его мылу
            var requests = await _merchandiseRepository
                .GetByEmployeeEmail(request.EmployeeEmail, cancellationToken);
            
            var merchandiseRequest = new MerchandiseRequest(0,
                preset,
                new Employee(eMail: request.EmployeeEmail, 
                    size: request.EmployeeClothingSize.ToString()), 
                RequestStatus.New,
                new CreateDate(DateTime.Now),
                new GiveOutDate(null));
            var id = await _merchandiseRepository.Create(merchandiseRequest, cancellationToken);
            
            if (request.Type.Equals(PresetType.WelcomePack.Name) || request.Type.Equals(PresetType.VeteranPack.Name))
            {
                var checkError = CheckPackTime(requests, preset.Type);
                if (checkError.isError)
                {
                    var merchandiseRequestToDecline = new MerchandiseRequest(id,
                        preset,
                        new Employee(eMail: request.EmployeeEmail, 
                            size: request.EmployeeClothingSize.ToString()), 
                        RequestStatus.Decline,
                        merchandiseRequest.CreateDate,
                        new GiveOutDate(null));
                    var declineId = await _merchandiseRepository.Create(merchandiseRequest, cancellationToken);
                    
                    throw new Exception(checkError.errorMessage);
                }
            }
            
            // Отправляем запрос на выдачу мерча которая вызывается из сток апи
            
            // проверяем что бронь прошла
            if (true)
            {
                var merchandiseRequestToDone = new MerchandiseRequest(id,
                    preset,
                    new Employee(eMail: request.EmployeeEmail, 
                        size: request.EmployeeClothingSize.ToString()), 
                    RequestStatus.Done,
                    merchandiseRequest.CreateDate,
                    new GiveOutDate(DateTime.Now));
                var doneId = await _merchandiseRepository.Create(merchandiseRequest, cancellationToken);
                
                return Unit.Value;
            }
            var merchandiseRequestToProcessing = new MerchandiseRequest(id,
                preset,
                new Employee(eMail: request.EmployeeEmail, 
                    size: request.EmployeeClothingSize.ToString()), 
                RequestStatus.Processing,
                merchandiseRequest.CreateDate,
                new GiveOutDate(null));
            var processingId = await _merchandiseRepository.Create(merchandiseRequest, cancellationToken);
                
            return Unit.Value;
        }

        private (bool isError, string errorMessage) CheckPackTime(IReadOnlyCollection<MerchandiseRequest> requests, PresetType currentPresentType)
        {
            // получаем запросы с типом велком пака или ветеран пака и сортируем 
            var lastPacks = requests.Where(it => it.SkuPreset.Type.Equals(currentPresentType)
                && it.RequestStatus.Equals(RequestStatus.Done))
                .OrderByDescending(it => it.GiveOutDate)
                .ToArray();
            if (lastPacks.Length <= 0) return (false, "");
            
            var lastPack = lastPacks.First();
            var giveOutDate = lastPack.GiveOutDate.Value;
            if (giveOutDate is null)
                return (false, "");
            var yearCount = giveOutDate.Value.Year - DateTime.Now.Year;
            return yearCount <= 0 ? (true, "A year has not passed to get a new pack") : (false, "");
        }
    }
}