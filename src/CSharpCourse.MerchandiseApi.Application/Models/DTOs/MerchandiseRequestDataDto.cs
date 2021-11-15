using System;

namespace CSharpCourse.MerchandiseApi.Application.Models.DTOs
{
    /// <summary>
    /// Информация о выдаваемом мерче сотруднику
    /// </summary>
    public record MerchandiseRequestDataDto
    {
        /// <summary>
        /// Тип выдаваемого мерча
        /// </summary>
        public string Type { get; init; }

        /// <summary>
        /// Статус заявки
        /// </summary>
        public string Status { get; init; }

        /// <summary>
        /// Дата создания заявки
        /// </summary>
        public DateTimeOffset CreatedAt { get; init; }

        /// <summary>
        /// Дата выдачи мерча
        /// </summary>
        public DateTimeOffset? GaveOutAt { get; init; }
    }
}
