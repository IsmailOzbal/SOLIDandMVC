using ExternalServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalServices.BO
{
    public class CustomerTypeDiscount : IDiscount
    {
        private readonly ICustomerService _customerService;
        private readonly IAccountsService _accountsService;
        public CustomerTypeDiscount(ICustomerService customerService, IAccountsService accountsService)
        {
            _customerService = customerService;
            _accountsService = accountsService;
        }

        public decimal GetDiscount(string id)
        {
            var customerAccount = _customerService.GetAccount(id);
            var accountPaymentHistory = _accountsService.GetAccountHistory(customerAccount.AccountId);

            var returnDiscount = 0M;
            //Gold Cuustomer
            if(customerAccount.CreatedOn.AddYears(3) <= DateTime.Now && accountPaymentHistory.YearlySpend >= 1000)
            {
                return 2;
            }
            //Silver Customer
            else if(customerAccount.CreatedOn.AddYears(2) <= DateTime.Now && accountPaymentHistory.YearlySpend >= 2000)
            {
                return 2;
            }
            else if(customerAccount.CreatedOn.AddYears(1) <= DateTime.Now && accountPaymentHistory.YearlySpend >= 3000)
            {
                return 1;
            }

            return returnDiscount;
        }
    }
}
