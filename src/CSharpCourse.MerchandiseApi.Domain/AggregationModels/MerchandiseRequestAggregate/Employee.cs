using System.Collections.Generic;
using CSharpCourse.MerchandiseApi.Domain.Models;

namespace CSharpCourse.MerchandiseApi.Domain.AggregationModels.MerchandiseRequestAggregate
{
    public class Employee : ValueObject
    {
        public string EMail { get; }
        public string Size { get; }
        
        public Employee(string eMail, string size)
        {
            EMail = eMail;
            Size = size;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return EMail;
            yield return Size;
        }
    }
}