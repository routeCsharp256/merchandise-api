using System.Collections.Generic;
using CSharpCourse.MerchandiseApi.Application.Models.DTOs;

namespace CSharpCourse.MerchandiseApi.Application.Queries
{
    public class GetRequestsByEmployeeQueryResponse
    {
        public IReadOnlyCollection<MerchRequestDataDto> Items { get; set; }
    }
}