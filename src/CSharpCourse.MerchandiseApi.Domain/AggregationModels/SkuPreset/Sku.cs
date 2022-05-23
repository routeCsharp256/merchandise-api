using System.Collections.Generic;
using CSharpCourse.MerchandiseApi.Domain.Root;

namespace CSharpCourse.MerchandiseApi.Domain.AggregationModels.SkuPreset
{
    public class Sku : ValueObject
    {
        private Sku(long value)
            => Value = value;

        public long Value { get; }

        public static Sku Create(long skuValue)
        {
            // TODO: здесь можно добавить всю неободимую валидациию, если надо
            if (skuValue > 0)
            {
                return new Sku(skuValue);
            }

            throw new DomainException($"SKU value is invalid: {skuValue}");
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
