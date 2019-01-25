using System;
using ExternalServices.Interfaces;

namespace ExternalServices.BO
{
    public class LongServiceDiscount : IDiscount
    {
        private readonly ICustomerService _customerService;
        public LongServiceDiscount(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public decimal GetDiscount(string id)
        {
            DateTime zeroTime = new DateTime(1, 1, 1);
            var customerAccount = _customerService.GetAccount(id);
            var returnDiscount = 0M;
            TimeSpan span = DateTime.Now - customerAccount.CreatedOn;
            int years = (zeroTime + span).Year - 1;
            if (years >= 1 && years < 2)
                returnDiscount = 0.25M;

            else if (years >= 2 && years < 3)
                returnDiscount = 0.5M;

            else if (years >= 3)
                returnDiscount = 1;

            return returnDiscount;

        }
    }
}
