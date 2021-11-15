using System.Collections.Generic;
using System.Text.RegularExpressions;
using CSharpCourse.MerchandiseApi.Domain.Root;

namespace CSharpCourse.MerchandiseApi.Domain.AggregationModels.MerchandiseRequest
{
    public class Email : ValueObject
    {
        public string Value { get; }

        private Email(string emailString)
            => Value = emailString;

        public static Email Create(string emailString)
        {
            if (IsValidEmail(emailString))
            {
                return new Email(emailString);
            }

            // TODO: тут конечно же должно быть нормальное исключение
            throw new DomainException($"Email is invalid: {emailString}");
        }

        /// <inheritdoc />
        public override string ToString()
            => Value;

        /// <inheritdoc />
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        private static bool IsValidEmail(string emailString)
            => Regex.IsMatch(emailString, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
    }
}
