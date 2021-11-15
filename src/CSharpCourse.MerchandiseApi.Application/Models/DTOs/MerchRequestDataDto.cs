using System;

namespace CSharpCourse.MerchandiseApi.Application.Models.DTOs
{
    public class MerchRequestDataDto
    {
        public string MerchType { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? GiveOutDate { get; set; }
    }
}