using System.Collections.Generic;
using CSharpCourse.MerchandiseApi.Domain.Root;

namespace CSharpCourse.MerchandiseApi.Domain.AggregationModels.MerchandiseRequest
{
    /// <summary>
    /// Информация о сотруднике
    /// </summary>
    public class Employee : ValueObject
    {
        public Employee(Email email, ClothingSize clothingSize)
        {
            Email = email;
            ClothingSize = clothingSize;
        }

        /// <summary>
        /// Адрес электронной почты сотрудника
        /// </summary>
        public Email Email { get; }

        /// <summary>
        /// Размер одежды
        /// </summary>
        public ClothingSize ClothingSize { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Email;
            yield return ClothingSize;
        }
    }
}