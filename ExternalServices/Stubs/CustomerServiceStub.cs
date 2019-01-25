using System;
using ExternalServices.DTO;
using ExternalServices.Interfaces;

namespace ExternalServices.Stubs
{
    public class CustomerServiceStub : ICustomerService
    {
        public CustomerAccount GetAccount(string id)
        {
            return new CustomerAccount()
            {
                AccountId = "1",
                CreatedOn = DateTime.Now.AddYears(-2)
            };
        }
    }
}