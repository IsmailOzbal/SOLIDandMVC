using ExternalServices.DTO;

namespace ExternalServices.Interfaces
{
    public interface IPackageService
    {
        Package GetPackage(string id);
    }
}
