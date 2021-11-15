using System.Collections.Generic;
using CSharpCourse.MerchandiseApi.Application.Models.DTOs;

namespace CSharpCourse.MerchandiseApi.Application.Queries.GetRequestsByEmployee
{
    public class GetRequestsByEmployeeQueryResponse
    {
        public IReadOnlyCollection<MerchandiseRequestDataDto> Items { get; set; }
    }
}
