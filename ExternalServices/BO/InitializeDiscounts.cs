using System.Collections.Generic;
using ExternalServices.Interfaces;

namespace ExternalServices.BO
{

    public class InitializeDiscounts : ITariffManager<List<IDiscount>>
    {
        private List<IDiscount> allDiscoutList;
        private readonly ICustomerService _customerService;
        private readonly IPackageService _packageService;
        private readonly IAccountsService _accountsService;

        public InitializeDiscounts(ICustomerService customerService, IPackageService packageService,
            IAccountsService accountsService)
        {
            _customerService = customerService;
            allDiscoutList = new List<IDiscount>();
            _packageService = packageService;
            _accountsService = accountsService;
        }

        public List<IDiscount> Manage()
        {
            //Define all existing discounts.
            allDiscoutList.Add(new LongServiceDiscount(_customerService));
            allDiscoutList.Add(new PackageDiscount(_packageService));
            allDiscoutList.Add(new BigSpenderDiscount(_customerService, _accountsService));
            allDiscoutList.Add(new CustomerTypeDiscount(_customerService, _accountsService));

            return allDiscoutList;

        }
    }
}
