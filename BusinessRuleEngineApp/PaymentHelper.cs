using System.Collections.Generic;

namespace BusinessRuleEngineApp
{
    /// <summary>
    /// Helper class to collect reequests and executes the request
    /// in a chain of responsibility manner.
    /// </summary>
    public class PaymentHelper
    {
        public PaymentRequest paymentRequestObj { get; set; }
        public PaymentHelper()
        {
            paymentRequestObj = new PaymentRequest();
            paymentRequestObj.RequestMessages = new List<string>();
        }

        /// <summary>
        /// Collect payment type as input
        /// Initialize payment classes in a chain responsibility structure
        /// and execute.
        /// </summary>
        /// <param name="paymentType">Type of the payment to executed</param>
        /// <returns></returns>
        public PaymentRequest ProcessPaymentRequest(string paymentType)
        {
            paymentRequestObj.PaymentType = paymentType;

            //Initialize payment types in a chain structure
            //so that each request traverse through each payment type until the request is processed.
            VideoPayment videoPaymentObj = new VideoPayment(null, paymentRequestObj);
            UpgradeToMembershipPayment upgradeToMembershipPaymentObj = new UpgradeToMembershipPayment(videoPaymentObj, paymentRequestObj);
            MembershipPayment membershipPaymentObj = new MembershipPayment(upgradeToMembershipPaymentObj, paymentRequestObj);
            BookPayment bookPaymentObj = new BookPayment(membershipPaymentObj, paymentRequestObj);
            PhysicalProductPayment physicalProductPaymentObj = new PhysicalProductPayment(bookPaymentObj, paymentRequestObj);

            physicalProductPaymentObj.HandleRequest();
            return paymentRequestObj;
        }
    }
}
