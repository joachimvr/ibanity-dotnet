using System;
using System.Runtime.Serialization;

namespace Ibanity.Apis.Client.Webhooks.Models.XS2A
{
    /// <summary>
    /// A webhook payload delivered whenever a payment initiation request authorization completes.
    /// </summary>
    public class PaymentInitiationRequestAuthorizationCompleted : JsonApi.Data, IWebhookEvent
    {
        /// <summary>
        /// Unique identifier of the associated payment initiation request.
        /// </summary>
        [DataMember(Name = "paymentInitiationRequestId", EmitDefaultValue = false)]
        public Guid PaymentInitiationRequestId { get; set; }

        /// <summary>
        /// Current status of the payment initiation request.
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public string Status { get; set; }

        /// <summary>
        /// When this notification was created.
        /// </summary>
        [DataMember(Name = "createdAt", EmitDefaultValue = false)]
        public DateTimeOffset CreatedAt { get; set; }
    }

    /// <summary>
    /// A webhook payload delivered whenever a payment initiation request is completed.
    /// </summary>
    public class NestedPaymentInitiationRequestAuthorizationCompleted : PayloadData<PaymentInitiationRequestAuthorizationCompletedAttributes, PaymentInitiationRequestAuthorizationCompletedRelationships>
    {
        /// <inheritdoc />
        public override IWebhookEvent Flatten() =>
            new PaymentInitiationRequestAuthorizationCompleted
            {
                Id = Id,
                Type = Type,
                PaymentInitiationRequestId = Guid.Parse(Relationships.PaymentInitiationRequest.Data.Id),
                Status = Attributes.Status,
                CreatedAt = Attributes.CreatedAt
            };
    }

    /// <summary>
    /// Payload attributes delivered whenever a payment initiation request is completed.
    /// </summary>
    public class PaymentInitiationRequestAuthorizationCompletedAttributes
    {
        /// <summary>
        /// When this notification was created.
        /// </summary>
        [DataMember(Name = "createdAt", EmitDefaultValue = false)]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Current status of the payment initiation request.
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public string Status { get; set; }
    }

    /// <summary>
    /// Payload relationships delivered whenever a payment initiation request is completed.
    /// </summary>
    public class PaymentInitiationRequestAuthorizationCompletedRelationships

        /// <summary>
        /// Details about the associated payment initiation request.
        /// </summary>
        [DataMember(Name = "paymentInitiationRequest", EmitDefaultValue = false)]
        public Relationship PaymentInitiationRequest { get; set; }
    }
}
