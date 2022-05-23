using MediatR;

namespace CSharpCourse.MerchandiseApi.Domain.AggregationModels.MerchandiseRequest.DomainEvents
{
    /// <summary>
    /// Событие о том, что мерч выдан
    /// </summary>
    public sealed record MerchandiseRequestGaveOut : INotification
    {
        /// <summary>
        /// Сотрудник, которому выдаем мерч
        /// </summary>
        public Employee Employee { get; init; }

        /// <summary>
        /// Набор мерча, который выдаем сотруднику
        /// </summary>
        public SkuPreset.SkuPreset Preset { get; init; }
    }
}
