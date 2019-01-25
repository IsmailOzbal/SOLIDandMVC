using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalServices.DTO
{
    public class Tariff
    {
        public string TariffName { get; set; }
        public string TariffFriendlyName { get; set; }
        public IEnumerable<string> TariffTerms { get; set; }
        public decimal AnnualGasCost { get; set; }
        public decimal AnnualElectricCost { get; set; }
        public decimal annualSum { get; set; }
        public decimal monthlyElectric { get; set; }
        public decimal monthlyGas { get; set; }
        public int monthlySumPound { get; set; }
        public decimal monthlySumPence { get; set; }
        public decimal discount { get; set; }
    }
}
