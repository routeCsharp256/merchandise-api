using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpCourse.MerchandiseApi.Domain.AggregationModels.MerchandiseRequestAggregate
{
    public interface IMerchandiseRepository
    {
        Task<int> Create(MerchandiseRequest value, CancellationToken cancellationToken);
        Task Update(MerchandiseRequest value, CancellationToken cancellationToken);
        Task Delete(MerchandiseRequest value, CancellationToken cancellationToken);
        Task<MerchandiseRequest> GetById(int id, CancellationToken cancellationToken);

        Task<IReadOnlyCollection<MerchandiseRequest>> GetByEmployeeEmail(string email,
            CancellationToken cancellationToken);
    }
}