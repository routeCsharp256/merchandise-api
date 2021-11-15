using System.Threading;
using System.Threading.Tasks;
using CSharpCourse.MerchandiseApi.Application.Commands;
using MediatR;

namespace CSharpCourse.MerchandiseApi.Application.Handlers
{
    public class NewMerchandiseAppearedCommandHandler : IRequestHandler<NewMerchandiseAppearedCommand>
    {
        public Task<Unit> Handle(NewMerchandiseAppearedCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}