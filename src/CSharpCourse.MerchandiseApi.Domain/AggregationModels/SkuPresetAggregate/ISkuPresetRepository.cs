using System.Threading;
using System.Threading.Tasks;

namespace CSharpCourse.MerchandiseApi.Domain.AggregationModels.SkuPresetAggregate
{
    public interface ISkuPresetRepository
    {
        Task<int> Create(SkuPreset value, CancellationToken cancellationToken);
        Task Update(SkuPreset value, CancellationToken cancellationToken);
        Task Delete(SkuPreset value, CancellationToken cancellationToken);
        Task<SkuPreset> GetById(int id, CancellationToken cancellationToken);
        Task<SkuPreset> GetByPresetType(PresetType type, CancellationToken cancellationToken);
    }
}