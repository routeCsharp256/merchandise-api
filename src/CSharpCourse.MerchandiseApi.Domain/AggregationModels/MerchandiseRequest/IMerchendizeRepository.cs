using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpCourse.MerchandiseApi.Domain.AggregationModels.MerchandiseRequest
{
    public interface IMerchandiseRepository
    {
        Task<int> CreateAsync(MerchandiseRequest request, CancellationToken cancellationToken);

        Task UpdateAsync(MerchandiseRequest value, CancellationToken cancellationToken);

        Task<MerchandiseRequest> GetByIdAsync(int id, CancellationToken cancellationToken);

        Task<IReadOnlyCollection<MerchandiseRequest>> GetByEmployeeEmailAsync(Email email,
            CancellationToken cancellationToken);

        Task<IReadOnlyCollection<MerchandiseRequest>> GetAllProcessingRequestsAsync(CancellationToken cancellationToken);
    }
}
