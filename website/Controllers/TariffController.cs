using System.Web.Mvc;
using ExternalServices.Interfaces;
using System;
using System.Globalization;

namespace website.Controllers
{
    public class TariffController : Controller
    {

        private readonly ICustomerService _customerService;
        private readonly IAccountsService _accountsService;
        private readonly IPackageService _packageService;
        private readonly ITariffService _tariffService;
        private readonly ITariffManager<string, decimal> _getTariff;
        public TariffController(ITariffManager<string, decimal> getTariff, ITariffService tariffService)
        {
            _getTariff = getTariff;
            _tariffService = tariffService;
        }


        [Route("Customers/GetCustomerTariffs")]
        public ActionResult GetCustomerTariffs(string accountNumber)
        {
            var data = _tariffService.GetTariffInfo(accountNumber);
            var discount = _getTariff.Manage(accountNumber);
            if (discount != 0)
            {
                foreach (var item in data.Tariffs)
                {
                    item.AnnualElectricCost = (item.AnnualElectricCost - (item.AnnualElectricCost * discount));
                    item.AnnualGasCost = (item.AnnualGasCost - (item.AnnualGasCost * discount));
                    item.annualSum = decimal.Round((item.AnnualElectricCost + item.AnnualGasCost), 2, MidpointRounding.AwayFromZero);
                    item.monthlyElectric = decimal.Round((item.AnnualElectricCost / 12), 2, MidpointRounding.AwayFromZero);
                    item.monthlyGas = decimal.Round((item.AnnualGasCost / 12), 2, MidpointRounding.AwayFromZero);
                    var values = Convert.ToDouble(item.monthlyElectric + item.monthlyGas).ToString(CultureInfo.InvariantCulture).Split('.');
                    int firstValue = int.Parse(values[0]);
                    int secondValue = int.Parse(values[1]);
                    item.monthlySumPound = firstValue;
                    item.monthlySumPence = secondValue;
                    item.discount = discount;
                }
            }
            return View(data);

        }

    }
}