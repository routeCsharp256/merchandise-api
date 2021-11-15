using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            var requests = await _merchandiseRepository.GetByEmployeeEmail(request.EmployeeEmail, cancellationToken);
            
            // получаем запросы с типом велком пака или ветеран пака
            var lastPresets = requests.Where(it => it.SkuPreset.Type.Equals(preset.Type))
                .OrderByDescending(it => it.GiveOutDate)
                .ToArray();
            
            // Если велком пак или ветеран пак уже вадавался то ошибка
            if (request.Type.Equals(PresetType.WelcomePack.Name) || request.Type.Equals(PresetType.VeteranPack.Name))
            {
                var welcomePackOrVeteran = requests.Any(it =>
                    it.SkuPreset.Type.Equals(PresetType.WelcomePack) ||
                    it.SkuPreset.Type.Equals(PresetType.VeteranPack));
                // получаем последние запросы с таким типом и сортируем их по времени от последнего к ранним
                var lastPresets = requests.Where(it => it.SkuPreset.Type.Equals(preset.Type))
                    .OrderByDescending(it => it.GiveOutDate)
                    .ToArray();
                if (lastPresets.Length > 0)
                {
                
                }
                if (welcomePackOrVeteran)
                    throw new Exception("This pack has already been issued");
            }
                
            
            

            var merchandiseRequest = new MerchandiseRequest(preset,
                new Employee(eMail: request.EmployeeEmail, 
                    size: request.EmployeeClothingSize.ToString()), 
                RequestStatus.New,
                new CreateDate(DateTime.Now),
                new GiveOutDate(null));    
            
        }
    }
}