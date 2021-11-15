using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSharpCourse.MerchandiseApi.Application.Models.DTOs;
using CSharpCourse.MerchandiseApi.Application.Queries;
using CSharpCourse.MerchandiseApi.Domain.AggregationModels.MerchandiseRequestAggregate;
using MediatR;

namespace CSharpCourse.MerchandiseApi.Application.Handlers
{
    public class GetRequestsByEmployeeQueryHandler : IRequestHandler<GetRequestsByEmployeeQuery, GetRequestsByEmployeeQueryResponse>
    {
        private readonly IMerchandiseRepository _repository;

        public GetRequestsByEmployeeQueryHandler(IMerchandiseRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetRequestsByEmployeeQueryResponse> Handle(GetRequestsByEmployeeQuery request, CancellationToken cancellationToken)
        {
            var requests = await _repository.GetByEmployeeEmail(request.Email, cancellationToken);
            return new GetRequestsByEmployeeQueryResponse()
            {
                Items = requests.Select(it => new MerchRequestDataDto()
                {
                    Status = it.RequestStatus.Name,
                    CreateDate = it.CreateDate.Value,
                    MerchType = it.SkuPreset.Type.Name,
                    GiveOutDate = it.GiveOutDate.Value
                }).ToArray()
            };
        }
    }
}