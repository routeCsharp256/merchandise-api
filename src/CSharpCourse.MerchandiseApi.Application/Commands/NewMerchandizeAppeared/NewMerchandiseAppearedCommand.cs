using System.Collections.Generic;
using MediatR;

namespace CSharpCourse.MerchandiseApi.Application.Commands
{
    public class NewMerchandiseAppearedCommand : IRequest
    {
        public IReadOnlyCollection<long> Skus { get; set; }
    }
}