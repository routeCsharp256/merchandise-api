using System.Collections.Generic;
using CSharpCourse.MerchandiseApi.Domain.Models;

namespace CSharpCourse.MerchandiseApi.Domain.AggregationModels.ValueObjects
{
    public class Sku : ValueObject
    {
        public long Value { get; }

        public Sku(long value)
        {
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}