using MediatR;

namespace CSharpCourse.MerchandiseApi.Application.Commands.GiveOutMerchandise
{
    /// <summary>
    /// Команда на создание запроса на выдачу мерча
    /// </summary>
    public record GiveOutMerchandiseCommand : IRequest<Unit>
    {
        /// <summary>
        /// Емейл сотрудника
        /// </summary>
        public string Email { get; init; }

        /// <summary>
        /// Размер одежды
        /// </summary>
        public string ClothingSize { get; init; }

        /// <summary>
        /// Тип набора выдаваемого мерча
        /// </summary>
        public string Type { get; init; }
    }
}
