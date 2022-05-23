using System.Threading;
using System.Threading.Tasks;

namespace CSharpCourse.MerchandiseApi.Domain.AggregationModels.SkuPreset
{
    public interface ISkuPresetRepository
    {
        /// <summary>
        /// Сохраняет набор мерча
        /// </summary>
        Task SaveAsync(SkuPreset value, CancellationToken cancellationToken);

        /// <summary>
        /// Получаем набор мерча по ID
        /// </summary>
        Task<SkuPreset> GetByIdAsync(long id, CancellationToken cancellationToken);

        /// <summary>
        /// Ищем по типу набора мерча
        /// </summary>
        Task<SkuPreset> FindByTypeAsync(PresetType type, CancellationToken cancellationToken);
    }
}
