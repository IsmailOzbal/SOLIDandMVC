using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalServices.DTO
{
    public class TariffInfo
    {
        public string PostCode { get; set; }
        public int AnnualGasUsage { get; set; }
        public int AnnualElectricUsage { get; set; }
        public IEnumerable<Tariff> Tariffs { get; set; }
    }

}
