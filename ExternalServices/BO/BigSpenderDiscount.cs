using ExternalServices.Interfaces;

namespace ExternalServices.BO
{
    public class BigSpenderDiscount : IDiscount
    {
        private readonly ICustomerService _customerService;
        private readonly IAccountsService _accountsService;

        public BigSpenderDiscount(ICustomerService customerService, IAccountsService accountsService)
        {
            _customerService = customerService;
            _accountsService = accountsService;
        }
        public decimal GetDiscount(string id)
        {
            var customerAccount = _customerService.GetAccount(id);
            var accountPaymentHistory = _accountsService.GetAccountHistory(customerAccount.AccountId);

            var returnDiscount = 0M;

            if (accountPaymentHistory.YearlySpend >= 500 && accountPaymentHistory.YearlySpend <= 1000)
                returnDiscount = 0.25M;
            else if (accountPaymentHistory.YearlySpend >= 1000 && accountPaymentHistory.YearlySpend <= 2000)
                returnDiscount = 0.5M;
            else if (accountPaymentHistory.YearlySpend >= 2000 && accountPaymentHistory.YearlySpend <= 5000)
                returnDiscount = 1;
            else if (accountPaymentHistory.YearlySpend >= 5000)
                returnDiscount = 2;

            return returnDiscount;
        }
    }
}
