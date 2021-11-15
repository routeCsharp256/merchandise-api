using System;
using System.Threading;
using System.Threading.Tasks;
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

        public Task<GetRequestsByEmployeeQueryResponse> Handle(GetRequestsByEmployeeQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}