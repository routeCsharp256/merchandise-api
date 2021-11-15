using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSharpCourse.MerchandiseApi.Application.Commands.GiveOutMerchandise;
using CSharpCourse.MerchandiseApi.Domain.AggregationModels.MerchandiseRequest;
using CSharpCourse.MerchandiseApi.Domain.AggregationModels.SkuPreset;
using MediatR;

namespace CSharpCourse.MerchandiseApi.Application.Handlers
{
    public class GiveOutMerchandiseCommandHandler : IRequestHandler<GiveOutMerchandiseCommand>
    {
        private readonly IMerchandiseRepository _merchandiseRepository;
        private readonly ISkuPresetRepository _skuPresetRepository;
        private readonly IStockApiIntegration _stockApiIntegration;

        public GiveOutMerchandiseCommandHandler(
            IMerchandiseRepository merchandiseRepository,
            ISkuPresetRepository skuPresetRepository,
            IStockApiIntegration stockApiIntegration)
        {
            _skuPresetRepository = skuPresetRepository;
            _stockApiIntegration = stockApiIntegration;
            _merchandiseRepository = merchandiseRepository;
        }

        public async Task<Unit> Handle(GiveOutMerchandiseCommand request, CancellationToken cancellationToken)
        {
            var preset = await _skuPresetRepository.FindByTypeAsync(PresetType.Parse(request.Type), cancellationToken);

            var alreadyExistsRequests = await _merchandiseRepository
                .GetByEmployeeEmailAsync(Email.Create(request.Email), cancellationToken);

            var newMerchandiseRequest = new MerchandiseRequest(
                skuPreset: preset,
                employee: new Employee(Email.Create(request.Email), ClothingSize.Parse(request.ClothingSize)),
                createdAt: DateTimeOffset.UtcNow);

            var newId = await _merchandiseRepository.CreateAsync(newMerchandiseRequest, cancellationToken);

            newMerchandiseRequest = new MerchandiseRequest(
                newId,
                newMerchandiseRequest.SkuPreset,
                newMerchandiseRequest.Employee,
                newMerchandiseRequest.Status,
                newMerchandiseRequest.CreatedAt,
                newMerchandiseRequest.GaveOutAt);

            var isSkuPackAvailable =
                await _stockApiIntegration.RequestGiveOutAsync(preset.SkuCollection.Select(sku => sku.Value), cancellationToken);

            newMerchandiseRequest.GiveOut(alreadyExistsRequests, isSkuPackAvailable, DateTimeOffset.UtcNow);

            await _merchandiseRepository.UpdateAsync(newMerchandiseRequest, cancellationToken);

            return Unit.Value;
        }
    }
}
