using ExternalServices.DTO;

namespace ExternalServices.Interfaces
{
    public interface ITariffService
    {
        TariffInfo GetTariffInfo(string accountNumber);
    }
}
