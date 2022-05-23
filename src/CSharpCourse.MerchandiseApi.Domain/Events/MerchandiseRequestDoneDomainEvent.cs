using MediatR;

namespace CSharpCourse.MerchandiseApi.Domain.Events
{
    public class MerchandiseRequestDoneDomainEvent : INotification
    {
        public string EmployeeEmail { get; set; }
        public string MerchPackType { get; set; }
    }
}