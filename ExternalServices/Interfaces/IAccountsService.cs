using ExternalServices.DTO;

namespace ExternalServices.Interfaces
{
    public interface IAccountsService
    {
        AccountHistory GetAccountHistory(string accountId);
    }
}
