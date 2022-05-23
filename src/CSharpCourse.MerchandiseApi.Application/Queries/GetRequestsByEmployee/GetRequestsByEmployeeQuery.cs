using MediatR;

namespace CSharpCourse.MerchandiseApi.Application.Queries.GetRequestsByEmployee
{
    /// <summary>
    /// Запрос на получение всех запросов на получение мерча для сотрудника
    /// </summary>
    public record GetRequestsByEmployeeQuery : IRequest<GetRequestsByEmployeeQueryResponse>
    {
        /// <summary>
        /// Электронная почта сотрудника
        /// </summary>
        public string Email { get; init; }
    }
}
