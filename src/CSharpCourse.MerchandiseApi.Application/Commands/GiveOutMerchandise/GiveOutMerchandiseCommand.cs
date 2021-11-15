using CSharpCourse.MerchandiseApi.Domain.Models.Enums;
using MediatR;

namespace CSharpCourse.MerchandiseApi.Application.Commands
{
    public class GiveOutMerchandiseCommand : IRequest
    {
        public string EmployeeEmail { get; set; }
        public ClothingSize EmployeeClothingSize { get; set; }
        // ССылка из общей либы которая core lib
        public string Type { get; set; }
    }
}