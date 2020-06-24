using System;
using System.Threading;

namespace BusinessRuleEngineApp
{
    /// <summary>
    /// Base class that contains the request obj and 
    /// a member of its own type. This is used to refer individual child classes during run time
    /// </summary>
    public abstract class PaymentBase
    {
        public PaymentBase NextPaymentType { get; private set; }
        public PaymentRequest RequestObj { get; private set; }

        public PaymentBase(PaymentBase nextHandler, PaymentRequest requestObj)
        {
            NextPaymentType = nextHandler;
            RequestObj = requestObj;
        }

        public abstract void HandleRequest();
    }

    /// <summary>
    /// class to handle Physical Product Payment
    /// </summary>
    public class PhysicalProductPayment : PaymentBase
    {
        public PhysicalProductPayment(PaymentBase nextHandler, PaymentRequest requestObj) : base(nextHandler, requestObj) { }

        public override void HandleRequest()
        {
            if (RequestObj.RequestStatus != Constants.SuccesssMessage)
            {
                Console.WriteLine("Physical Product Payment process checking...\n");
                Thread.Sleep(1000);
                if (RequestObj.PaymentType == Constants.PhysicalProductPayment)
                {
                    //TO DO - Genererated a packaging slip for shipping
                    RequestObj.RequestMessages.Add("Genererated a packaging slip for shipping");
                    RequestObj.RequestStatus = Constants.SuccesssMessage;
                }
                else
                {
                    RequestObj.RequestStatus = Constants.FailureMessage;
                }
            }
            NextPaymentType.HandleRequest();
        }
    }

    /// <summary>
    /// class to handle Book Payment
    /// </summary>
    public class BookPayment : PaymentBase
    {
        public BookPayment(PaymentBase nextHandler, PaymentRequest requestObj) : base(nextHandler, requestObj) { }

        public override void HandleRequest()
        {
            if (RequestObj.RequestStatus != Constants.SuccesssMessage)
            {
                Console.WriteLine("Book  Payment process checking...\n");
                Thread.Sleep(1000);
                if (RequestObj.PaymentType == Constants.BookPayment)
                {
                    //TO DO - Create duplicate packaging slip for shipping royality department
                    RequestObj.RequestMessages.Add("Created duplicate packaging slip for shipping royality department");
                    RequestObj.RequestStatus = Constants.SuccesssMessage;
                }
                else
                {
                    RequestObj.RequestStatus = Constants.FailureMessage;
                }
            }
            NextPaymentType.HandleRequest();
        }
    }

    /// <summary>
    /// class to handle Membership Payment
    /// </summary>
    public class MembershipPayment : PaymentBase
    {
        public MembershipPayment(PaymentBase nextHandler, PaymentRequest requestObj) : base(nextHandler, requestObj) { }

        public override void HandleRequest()
        {
            if (RequestObj.RequestStatus != Constants.SuccesssMessage)
            {
                Console.WriteLine("Membership Payment process checking...\n");
                Thread.Sleep(1000);
                if (RequestObj.PaymentType == Constants.MembershipPayment)
                {
                    //TO DO - Activate membership
                    RequestObj.RequestMessages.Add("Activate membership");
                    RequestObj.RequestStatus = Constants.SuccesssMessage;
                }
                else
                {
                    RequestObj.RequestStatus = Constants.FailureMessage;
                }
            }
            NextPaymentType.HandleRequest();
        }
    }

    /// <summary>
    /// class to handle Upgrade To Membrship Payment
    /// </summary>
    public class UpgradeToMembershipPayment : PaymentBase
    {
        public UpgradeToMembershipPayment(PaymentBase nextHandler, PaymentRequest requestObj) : base(nextHandler, requestObj) { }

        public override void HandleRequest()
        {
            if (RequestObj.RequestStatus != Constants.SuccesssMessage)
            {
                Console.WriteLine("Upgrade To Membrship Payment process checking...\n");
                Thread.Sleep(1000);
                if (RequestObj.PaymentType == Constants.UpgradeToMembershipPayment)
                {
                    //TO DO - Apply Upgare and send email 
                    RequestObj.RequestMessages.Add("Membership upgraded and email send");
                    RequestObj.RequestStatus = Constants.SuccesssMessage;
                }
                else
                {
                    RequestObj.RequestStatus = Constants.FailureMessage;
                }
            }
            NextPaymentType.HandleRequest();
        }
    }

    /// <summary>
    /// class to handle Video Payment
    /// </summary>
    public class VideoPayment : PaymentBase
    {
        public VideoPayment(PaymentBase nextHandler, PaymentRequest requestObj) : base(nextHandler, requestObj) { }
        public override void HandleRequest()
        {
            if (RequestObj.RequestStatus != Constants.SuccesssMessage)
            {
                Console.WriteLine("Video Payment process checking...\n");
                Thread.Sleep(1000);
                if (RequestObj.PaymentType == Constants.VideoPayment)
                {
                    //TO DO - Add a Free Aid video to packing slip
                    RequestObj.RequestMessages.Add("Added a Free Aid video to packing slip");
                    RequestObj.RequestStatus = Constants.SuccesssMessage;
                }
                else
                {
                    RequestObj.RequestStatus = Constants.FailureMessage;
                }
            }
        }
    }
}
