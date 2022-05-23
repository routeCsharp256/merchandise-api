using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSharpCourse.MerchandiseApi.Application.Models.DTOs;
using CSharpCourse.MerchandiseApi.Application.Queries.GetRequestsByEmployee;
using CSharpCourse.MerchandiseApi.Domain.AggregationModels.MerchandiseRequest;
using MediatR;

namespace CSharpCourse.MerchandiseApi.Application.Handlers
{
    public class GetRequestsByEmployeeQueryHandler : IRequestHandler<GetRequestsByEmployeeQuery, GetRequestsByEmployeeQueryResponse>
    {
        private readonly IMerchandiseRepository _repository;

        public GetRequestsByEmployeeQueryHandler(IMerchandiseRepository repository)
            => _repository = repository;

        public async Task<GetRequestsByEmployeeQueryResponse> Handle(GetRequestsByEmployeeQuery request, CancellationToken cancellationToken)
        {
            var requests = await _repository.GetByEmployeeEmailAsync(Email.Create(request.Email), cancellationToken);

            return new GetRequestsByEmployeeQueryResponse
            {
                Items = requests.Select(it => new MerchandiseRequestDataDto
                {
                    Status = it.Status.Name,
                    CreatedAt = it.CreatedAt,
                    Type = it.SkuPreset.Type.Name,
                    GaveOutAt = it.GaveOutAt,
                }).ToArray()
            };
        }
    }
}
