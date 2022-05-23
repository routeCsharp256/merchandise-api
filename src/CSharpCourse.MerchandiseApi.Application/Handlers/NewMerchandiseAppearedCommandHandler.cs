using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSharpCourse.MerchandiseApi.Application.Commands.NewMerchandizeAppeared;
using CSharpCourse.MerchandiseApi.Domain.AggregationModels.MerchandiseRequest;
using MediatR;

namespace CSharpCourse.MerchandiseApi.Application.Handlers
{
    public class NewMerchandiseAppearedCommandHandler : IRequestHandler<NewMerchandiseAppearedCommand>
    {
        private readonly IMerchandiseRepository _merchandiseRepository;
        private readonly IStockApiIntegration _stockApiIntegration;

        public NewMerchandiseAppearedCommandHandler(IMerchandiseRepository merchandiseRepository, IStockApiIntegration stockApiIntegration)
        {
            _merchandiseRepository = merchandiseRepository;
            _stockApiIntegration = stockApiIntegration;
        }

        public async Task<Unit> Handle(NewMerchandiseAppearedCommand request, CancellationToken cancellationToken)
        {
            var allProcessingRequests = await _merchandiseRepository.GetAllProcessingRequestsAsync(cancellationToken);

            allProcessingRequests = allProcessingRequests
                .Where(it => it.SkuPreset.SkuCollection.Any(sku => request.SkuCollection.Contains(sku.Value)))
                .OrderBy(it => it.CreatedAt)
                .ToArray();

            foreach (var processingRequest in allProcessingRequests)
            {
                // Отправляем запрос на выдачу мерча которая вызывается из сток апи
                var isAvailable =
                    await _stockApiIntegration.RequestGiveOutAsync(
                        processingRequest.SkuPreset.SkuCollection.Select(sku => sku.Value),
                        cancellationToken);

                processingRequest.GiveOut(isAvailable, DateTimeOffset.UtcNow);
            }

            return Unit.Value;
        }
    }
}
