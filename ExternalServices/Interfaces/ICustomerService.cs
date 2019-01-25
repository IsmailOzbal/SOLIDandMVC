using ExternalServices.DTO;

namespace ExternalServices.Interfaces
{
    public interface ICustomerService
    {
        CustomerAccount GetAccount(string id);
    }
}
