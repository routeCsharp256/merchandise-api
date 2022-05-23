using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpCourse.MerchandiseApi.Domain.AggregationModels.SkuPreset;

namespace CSharpCourse.MerchandiseApi.Infrastructure.Repositories
{
    public sealed class MockSkuPresetRepository : ISkuPresetRepository
    {
        /// <inheritdoc />
        public Task SaveAsync(SkuPreset value, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<SkuPreset> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<SkuPreset> FindByTypeAsync(PresetType type, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
