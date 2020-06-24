using System;

namespace BusinessRuleEngineApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IPaymentRequest request;
            int paymentType = -1;
            bool validOption = false;
            string paymentOption = string.Empty;

            //Print payment options in console
            foreach (var key in Constants.DictPaymentMethods.Keys)
            {
                Console.WriteLine(key + "." + Constants.DictPaymentMethods[key]);
            }

            //Accept valid user input.
            do
            {
                Console.WriteLine("\nChoose a Payment Type Number listed above and press any Enter");
                paymentOption = Console.ReadLine();
                int.TryParse(paymentOption, out paymentType);
                if (string.IsNullOrWhiteSpace(paymentOption))
                {
                    validOption = false;
                }
                else
                {
                    if (Constants.DictPaymentMethods.ContainsKey(paymentType))
                    {
                        validOption = true;
                    }
                }

            } while (validOption == false);

            Console.WriteLine("\nPlease wait while processing payment option : " + Constants.DictPaymentMethods[paymentType] + "\n");

            //process request
            PaymentHelper objHelper = new PaymentHelper();
            request = objHelper.ProcessPaymentRequest(Constants.DictPaymentMethods[paymentType]);

            Console.WriteLine("\n\n---Order Processing Status---");
            //Print the request status
            if (!string.IsNullOrWhiteSpace(request.RequestStatus))
            {
                if (request.RequestStatus == Constants.SuccesssMessage)
                {
                    Console.WriteLine(string.Concat(request.PaymentType, " ", request.RequestStatus));
                }
                else
                {
                    Console.WriteLine(request.RequestStatus);
                }
            }
            Console.ReadLine();
        }
    }
}
