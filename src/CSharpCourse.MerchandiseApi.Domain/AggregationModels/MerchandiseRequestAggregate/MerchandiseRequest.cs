using System.Collections.Generic;
using CSharpCourse.MerchandiseApi.Domain.AggregationModels.SkuPresetAggregate;
using CSharpCourse.MerchandiseApi.Domain.AggregationModels.ValueObjects;
using CSharpCourse.MerchandiseApi.Domain.Models;

namespace CSharpCourse.MerchandiseApi.Domain.AggregationModels.MerchandiseRequestAggregate
{
    public class MerchandiseRequest : Entity
    {
        public MerchandiseRequest(SkuPreset skuPreset, 
            Employee employee, 
            RequestStatus requestStatus, 
            CreateDate createDate, 
            GiveOutDate giveOutDate)
        {
            SkuPreset = skuPreset;
            Employee = employee;
            RequestStatus = requestStatus;
            CreateDate = createDate;
            GiveOutDate = giveOutDate;
        }

        public SkuPreset SkuPreset { get; }
        public Employee Employee { get; }
        public RequestStatus RequestStatus { get; }
        public CreateDate CreateDate { get; }
        public GiveOutDate GiveOutDate { get; }
    }
}