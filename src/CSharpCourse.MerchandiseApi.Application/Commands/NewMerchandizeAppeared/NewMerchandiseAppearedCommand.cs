using System.Collections.Generic;
using MediatR;

namespace CSharpCourse.MerchandiseApi.Application.Commands.NewMerchandizeAppeared
{
    /// <summary>
    /// Прибыл новый набор мерча
    /// </summary>
    public class NewMerchandiseAppearedCommand : IRequest<Unit>
    {
        /// <summary>
        /// Набор доступных артикулов
        /// </summary>
        public IReadOnlyCollection<long> SkuCollection { get; init; }
    }
}
