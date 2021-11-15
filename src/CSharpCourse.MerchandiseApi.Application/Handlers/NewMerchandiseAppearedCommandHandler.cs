using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSharpCourse.MerchandiseApi.Application.Commands;
using CSharpCourse.MerchandiseApi.Domain.AggregationModels.MerchandiseRequestAggregate;
using MediatR;

namespace CSharpCourse.MerchandiseApi.Application.Handlers
{
    public class NewMerchandiseAppearedCommandHandler : IRequestHandler<NewMerchandiseAppearedCommand>
    {
        private readonly IMerchandiseRepository _repository;

        public NewMerchandiseAppearedCommandHandler(IMerchandiseRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(NewMerchandiseAppearedCommand request, CancellationToken cancellationToken)
        {
            var allProcessingRequests = await _repository.GetAllProcessingRequests(cancellationToken);
            allProcessingRequests = allProcessingRequests
                .Where(it => it.SkuPreset.Skus.Any(sku => request.Skus.Contains(sku.Value)))
                .OrderBy(it => it.CreateDate)
                .ToArray();

            foreach (var processingRequest in allProcessingRequests)
            {
                // Отправляем запрос на выдачу мерча которая вызывается из сток апи
            
                // проверяем что бронь прошла
                if (true)
                {
                    var merchandiseRequestToDone = new MerchandiseRequest(processingRequest.Id,
                        processingRequest.SkuPreset,
                        processingRequest.Employee, 
                        RequestStatus.Done,
                        processingRequest.CreateDate,
                        new GiveOutDate(DateTime.Now));
                    var doneId = await _repository.Create(merchandiseRequestToDone, cancellationToken);
                
                    return Unit.Value;
                }
                var merchandiseRequestToProcessing = new MerchandiseRequest(processingRequest.Id,
                    processingRequest.SkuPreset,
                    processingRequest.Employee, 
                    RequestStatus.Processing,
                    processingRequest.CreateDate,
                    new GiveOutDate(null));
                var processingId = await _repository.Create(merchandiseRequestToProcessing, cancellationToken);
                
                return Unit.Value;    
            }
            return Unit.Value;
        }
    }
}