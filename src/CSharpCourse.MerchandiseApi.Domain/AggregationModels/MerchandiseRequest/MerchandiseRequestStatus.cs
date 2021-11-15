using CSharpCourse.MerchandiseApi.Domain.Root;

namespace CSharpCourse.MerchandiseApi.Domain.AggregationModels.MerchandiseRequest
{
    /// <summary>
    /// Статус заявки на выдачу мерча
    /// </summary>
    public class MerchandiseRequestStatus : Enumeration
    {
        /// <summary>
        /// Новая заявка
        /// </summary>
        public static MerchandiseRequestStatus New = new(1, "new");

        /// <summary>
        /// Заявка обрабатывается
        /// </summary>
        public static MerchandiseRequestStatus Processing = new(2, "processing");

        /// <summary>
        /// Заявка обработана
        /// </summary>
        public static MerchandiseRequestStatus Done = new(3, "done");

        /// <summary>
        /// Заявка отклонена
        /// </summary>
        public static MerchandiseRequestStatus Declined = new(4, "declined");
        
        public MerchandiseRequestStatus(int id, string name)
            : base(id, name)
        {
        }
    }
}
