using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExternalServices.DTO;
using ExternalServices.Interfaces;

namespace ExternalServices.BO
{
    public class PackageDiscount : IDiscount
    {
        private readonly IPackageService _packageService;
        public PackageDiscount(IPackageService packageService)
        {
            _packageService = packageService;
        }
        public decimal GetDiscount(string id)
        {
            var customerPackage = _packageService.GetPackage(id);
            var returnDiscount = 0M;

            if ((customerPackage.BroadbandType == BroadbandType.Basic &&
                 customerPackage.FuelType == FuelType.DualFuel) ||
                (customerPackage.BroadbandType == BroadbandType.HighSpeed &&
                 customerPackage.FuelType == FuelType.Electricity) ||
                (customerPackage.BroadbandType == BroadbandType.HighSpeed && customerPackage.FuelType == FuelType.Gas))
                returnDiscount= 5;

            if (customerPackage.FuelType == FuelType.DualFuel &&
                customerPackage.BroadbandType == BroadbandType.HighSpeed)
                returnDiscount= 10;

            return returnDiscount;
        }
    }
}
