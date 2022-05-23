using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpCourse.MerchandiseApi.Application
{
    /// <summary>
    /// Интерфейс взаимодействия со Stock API
    /// </summary>
    public interface IStockApiIntegration
    {
        /// <summary>
        /// Запрашиваем выдачу мерча
        /// </summary>
        Task<bool> RequestGiveOutAsync(IEnumerable<long> skuCollection, CancellationToken cancellationToken);
    }
}
