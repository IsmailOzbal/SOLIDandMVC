using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExternalServices.Interfaces;

namespace ExternalServices.BO
{
   public class GetCustomersBestDiscount: ITariffManager<string,decimal>
    {
        private readonly ITariffManager<List<IDiscount>> _initializeDiscount;

        public GetCustomersBestDiscount(ITariffManager<List<IDiscount>> initializeDiscount)
        {
            _initializeDiscount = initializeDiscount;
        }

        public decimal Manage(string id)
        {
            var allDiscounts = _initializeDiscount.Manage();

            decimal defaultDiscount = 0M;
            var currentDiscount = 0M;
            foreach (var discountObj in allDiscounts)
            {
                currentDiscount = discountObj.GetDiscount(id);
                if (defaultDiscount < currentDiscount)
                {
                    defaultDiscount = currentDiscount;
                }
            }

            return defaultDiscount;
        }

    }
}
