using System.Collections.Generic;
using ExternalServices.DTO;
using ExternalServices.Interfaces;

namespace ExternalServices.Stubs
{
    public class TariffServiceStub : ITariffService
    {
        public TariffInfo GetTariffInfo(string accountNumber)
        {
            return new TariffInfo
            {
                PostCode = "AB123CD",
                AnnualElectricUsage = 3643,
                AnnualGasUsage = 14310,
                Tariffs = new List<Tariff>
                {
                    new Tariff
                    {
                        TariffName = "SSE 1 Year Fixed v15 tariff",
                        TariffFriendlyName = "Fix your energy prices for 12 months",
                        TariffTerms = new List<string>
                        {
                            "£25 per fuel early exit fee"
                        },
                        AnnualElectricCost = 683.52M,
                        AnnualGasCost = 669.48M
                    },
                    new Tariff
                    {
                        TariffName = "SSE 1 Year Fix and Protect tariff",
                        TariffFriendlyName = "Fix your energy prices for 1 year with SSE Heating Breakdown Cover included",
                        TariffTerms = new List<string>
                        {
                            "£25 per fuel early exit fee",
                            "Includes 1 year free SSE Heating Breakdown Cover worth £83.40 (£6.95 per month) – £90 excess per call out and other terms and conditions apply."
                        },
                        AnnualElectricCost = 683.52M,
                        AnnualGasCost = 671.04M
                    },
                    new Tariff
                    {
                        TariffName = "SSE Smart 1 Year Fixed tariff",
                        TariffFriendlyName = "Get a smart meter and £50 credit",
                        TariffTerms = new List<string>
                        {
                            "No early exit fee",
                            "£50 electricity credit at the end of your tariff subject to your terms and conditions"
                        },
                        AnnualElectricCost = 705M,
                        AnnualGasCost = 692.04M
                    }
                }
            };
        }
    }
}
