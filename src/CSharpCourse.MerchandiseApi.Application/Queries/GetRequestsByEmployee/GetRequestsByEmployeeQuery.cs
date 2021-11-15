using MediatR;

namespace CSharpCourse.MerchandiseApi.Application.Queries
{
    public class GetRequestsByEmployeeQuery : IRequest<GetRequestsByEmployeeQueryResponse>
    {
        public string Email { get; set; }
    }
}