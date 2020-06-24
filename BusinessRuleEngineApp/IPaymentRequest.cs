using System.Collections.Generic;

namespace BusinessRuleEngineApp
{
    //interface to handle payment request messages
    interface IPaymentRequest
    {
        /// <summary>
        /// type of payment request
        /// </summary>
        string PaymentType { get; set; }

        /// <summary>
        /// status of the request(sucesss/failure)
        /// </summary>
        string RequestStatus { get; set; }

        /// <summary>
        /// list of sucess/error messages 
        /// </summary>
        List<string> RequestMessages { get; set; }
    }
}
