using System;
using ExternalServices.DTO;
using ExternalServices.Interfaces;

namespace ExternalServices.Stubs
{
    public class PackageServiceStub : IPackageService
    {
        public Package GetPackage(string id)
        {
            return new Package();
        }
    }
}