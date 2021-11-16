using System;
using System.Collections.Generic;
using CSharpCourse.MerchandiseApi.Domain.AggregationModels.MerchandiseRequest.DomainEvents;
using CSharpCourse.MerchandiseApi.Domain.Root;

namespace CSharpCourse.MerchandiseApi.Domain.AggregationModels.MerchandiseRequest
{
    public sealed class MerchandiseRequest : Entity
    {
        public MerchandiseRequest(
            long id,
            SkuPreset.SkuPreset skuPreset,
            Employee employee,
            MerchandiseRequestStatus status,
            DateTimeOffset createdAt,
            DateTimeOffset? gaveOutAt)
        {
            Id = id;
            SkuPreset = skuPreset;
            Employee = employee;
            Status = status;
            CreatedAt = createdAt;
            GaveOutAt = gaveOutAt;
        }

        /// <summary>
        /// Идентификатор набора мерча
        /// </summary>
        public SkuPreset.SkuPreset SkuPreset { get; }

        /// <summary>
        /// Информация о сотруднике
        /// </summary>
        public Employee Employee { get; }

        /// <summary>
        /// Статус запроса
        /// </summary>
        public MerchandiseRequestStatus Status { get; private set; }

        /// <summary>
        /// Дата создания запроса
        /// </summary>
        public DateTimeOffset CreatedAt { get; }

        /// <summary>
        /// Дата выдачи мерча
        /// </summary>
        public DateTimeOffset? GaveOutAt { get; private set; }

        private MerchandiseRequest(SkuPreset.SkuPreset skuPreset, Employee employee, DateTimeOffset createdAt)
        {
            SkuPreset = skuPreset;
            Employee = employee;
            CreatedAt = createdAt;
            Status = MerchandiseRequestStatus.New;
        }

        public static MerchandiseRequest Create(
            SkuPreset.SkuPreset skuPreset,
            Employee employee,
            IReadOnlyCollection<MerchandiseRequest> alreadyExistedRequest,
            DateTimeOffset createdAt)
        {
            var newRequest = new MerchandiseRequest(skuPreset, employee, createdAt);

            if (!newRequest.CheckAbilityToGiveOut(alreadyExistedRequest, createdAt))
            {
                throw new DomainException("Merchandize is unable to gave out");
            }

            return newRequest;
        }

        /// <summary>
        /// Выдаем мерч
        /// </summary>
        public void GiveOut(
            bool isAvailable,
            DateTimeOffset gaveOutAt)
        {
            if (Equals(Status, MerchandiseRequestStatus.New) || Equals(Status, MerchandiseRequestStatus.Processing))
            {
                if (isAvailable)
                {

                    Status = MerchandiseRequestStatus.Done;
                    GaveOutAt = gaveOutAt;

                    AddDomainEvent(new MerchandiseRequestGaveOut
                    {
                        Preset = SkuPreset,
                        Employee = Employee,
                    });
                }
                else
                {
                    Status = MerchandiseRequestStatus.Processing;
                }
            }
            else
            {
                throw new DomainException($"Unable to give out merchandise for request in '{Status}' status");
            }
        }

        /// <summary>
        /// Отклоняем выдачу мерча
        /// </summary>
        public void Decline()
        {
            if (Equals(Status, MerchandiseRequestStatus.Done) || Equals(Status, MerchandiseRequestStatus.Declined))
            {
                throw new DomainException($"Unable to decline merchandise request in '{Status}' status");
            }

            Status = MerchandiseRequestStatus.Declined;
        }

        /// <summary>
        /// Проверяем возможность выдать мерч сотруднику
        /// </summary>
        private bool CheckAbilityToGiveOut(
            IReadOnlyCollection<MerchandiseRequest> alreadyExistedRequest,
            DateTimeOffset gaveOutAt)
        {
            return true;
        }
    }
}
