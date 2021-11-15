using System;

namespace CSharpCourse.MerchandiseApi.Domain.AggregationModels.MerchandiseRequestAggregate
{
    public class GiveOutDate
    {
        public GiveOutDate(DateTime? value)
        {
            Value = value;
        }

        public DateTime? Value { get; }
    }
}