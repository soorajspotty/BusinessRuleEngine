using System.Collections.Generic;

namespace BusinessRuleEngineApp
{
    /// <summary>
    /// A class with concrete implementation of IPaymentRequest interface
    /// This can be refered using IPaymentRequest type where ever required
    /// </summary>
    public class PaymentRequest : IPaymentRequest
    {
        public string PaymentType { get; set; }

        public string RequestStatus { get; set; }
        public List<string> RequestMessages { get; set; }
    }
}
