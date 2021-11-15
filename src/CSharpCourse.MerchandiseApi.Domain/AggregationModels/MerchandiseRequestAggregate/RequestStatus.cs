using CSharpCourse.MerchandiseApi.Domain.Models;

namespace CSharpCourse.MerchandiseApi.Domain.AggregationModels.MerchandiseRequestAggregate
{
    public class RequestStatus : Enumeration
    {
        public static RequestStatus New = new(1, "new");
        public static RequestStatus Done = new(2, "done");
        public static RequestStatus Processing = new(3, "processing");
        public static RequestStatus Decline = new(4, "decline");
        
        public RequestStatus(int id, string name) : base(id, name)
        {
        }
    }
}