using System;

namespace CSharpCourse.MerchandiseApi.Domain.AggregationModels.MerchandiseRequestAggregate
{
    public class CreateDate
    {
        public CreateDate(DateTime value)
        {
            Value = value;
        }

        public DateTime Value { get; }
    }
}