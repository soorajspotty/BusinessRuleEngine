using System.Collections.Generic;

namespace BusinessRuleEngineApp
{
    /// <summary>
    /// Common location to contain all the strings 
    /// used in the application
    /// </summary>
    public static class Constants
    {
        public const string SuccesssMessage = "Successfully processed";
        public const string FailureMessage = "Processing Failed";

        public const string PhysicalProductPayment = "Physical Product Payment";
        public const string BookPayment = "Book Payment";
        public const string MembershipPayment = "Membership Payment";
        public const string UpgradeToMembershipPayment = "Upgrade To Membership Payment";
        public const string VideoPayment = "Video Payment";

        //Form a static readonly payment options dictionary to be used anywhere in application.
        public readonly static Dictionary<int, string> DictPaymentMethods = new Dictionary<int, string>()
        {
            { 1, PhysicalProductPayment},
            { 2, BookPayment},
            { 3, MembershipPayment},
            { 4, UpgradeToMembershipPayment},
            { 5, VideoPayment}
        };
    }
}
