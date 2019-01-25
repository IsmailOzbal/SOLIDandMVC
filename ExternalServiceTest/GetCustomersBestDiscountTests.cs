using ExternalServices.BO;
using ExternalServices.DTO;
using ExternalServices.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ExternalServiceTest
{
    [TestFixture]
    public class GetCustomersBestDiscountTests
    {
        private GetCustomersBestDiscount _getCustomerBestDiscount;

        [SetUp]
        public void Init()
        {
        }

        [Test]
        public void GetCustomerBestDiscountSpend600TwoYearsOnlyElectricityBroadbandTypeBasicShouldReturn5Percentange()
        {
            Mock<ITariffManager<List<IDiscount>>> initServiceMock = new Mock<ITariffManager<List<IDiscount>>>();
            initServiceMock.Setup(x => x.Manage()).Returns(ListDiscount());

            _getCustomerBestDiscount = new GetCustomersBestDiscount(initServiceMock.Object);

            var result = _getCustomerBestDiscount.Manage(It.IsAny<string>());

            Assert.AreEqual(result, 0.5M);
        }

        [Test]
        public void GetCustomerBestDiscountSpend2200FourYearsDualFuelBroadbandTypeHighSpeedShouldReturn5Percentange()
        {
            Mock<ITariffManager<List<IDiscount>>> initServiceMock = new Mock<ITariffManager<List<IDiscount>>>();
            initServiceMock.Setup(x => x.Manage()).Returns(ListDiscountSecond());

            _getCustomerBestDiscount = new GetCustomersBestDiscount(initServiceMock.Object);

            var result = _getCustomerBestDiscount.Manage(It.IsAny<string>());

            Assert.AreEqual(result, 10);
        }


        public List<IDiscount> ListDiscount()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(GetTwoYearsAccount());

            Mock<IAccountsService> accountServiceMock = new Mock<IAccountsService>();
            accountServiceMock.Setup(x => x.GetAccountHistory(It.IsAny<string>())).Returns(GetAccountHistorySpent600());

            Mock<IPackageService> packageServiceMock = new Mock<IPackageService>();
            packageServiceMock.Setup(x => x.GetPackage(It.IsAny<string>())).Returns(GetHighSpeedOnlyElectricityPackage());

            List<IDiscount> allDiscoutList = new List<IDiscount>();
            //Define all existing discounts.
            allDiscoutList.Add(new LongServiceDiscount(customerServiceMock.Object));
            allDiscoutList.Add(new PackageDiscount(packageServiceMock.Object));
            allDiscoutList.Add(new BigSpenderDiscount(customerServiceMock.Object, accountServiceMock.Object));
            allDiscoutList.Add(new CustomerTypeDiscount(customerServiceMock.Object, accountServiceMock.Object));

            return allDiscoutList;

        }

        public List<IDiscount> ListDiscountSecond()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(GetFourYearsAccount());

            Mock<IAccountsService> accountServiceMock = new Mock<IAccountsService>();
            accountServiceMock.Setup(x => x.GetAccountHistory(It.IsAny<string>())).Returns(GetAccountHistorySpent2200());

            Mock<IPackageService> packageServiceMock = new Mock<IPackageService>();
            packageServiceMock.Setup(x => x.GetPackage(It.IsAny<string>())).Returns(GetHighSpeedFuelTypePackage());

            List<IDiscount> allDiscoutList = new List<IDiscount>();
            //Define all existing discounts.
            allDiscoutList.Add(new LongServiceDiscount(customerServiceMock.Object));
            allDiscoutList.Add(new PackageDiscount(packageServiceMock.Object));
            allDiscoutList.Add(new BigSpenderDiscount(customerServiceMock.Object, accountServiceMock.Object));
            allDiscoutList.Add(new CustomerTypeDiscount(customerServiceMock.Object, accountServiceMock.Object));

            return allDiscoutList;

        }
        
        private AccountHistory GetAccountHistorySpent600()
        {
            return new AccountHistory()
            {
                YearlySpend = 600M
            };
        }

        private AccountHistory GetAccountHistorySpent2200()
        {
            return new AccountHistory()
            {
                YearlySpend = 2200M
            };
        }

        private CustomerAccount GetTwoYearsAccount()
        {
            return new CustomerAccount()
            {
                AccountId = "1",
                CreatedOn = DateTime.Now.AddYears(-2)

            };
        }

        private CustomerAccount GetFourYearsAccount()
        {
            return new CustomerAccount()
            {
                AccountId = "1",
                CreatedOn = DateTime.Now.AddYears(-4)

            };
        }

        public Package GetHighSpeedOnlyElectricityPackage()
        {
            return new Package
            {
                BroadbandType = BroadbandType.Basic,
                FuelType = FuelType.Electricity

            };
        }

        public Package GetHighSpeedFuelTypePackage()
        {
            return new Package
            {
                BroadbandType = BroadbandType.HighSpeed,
                FuelType = FuelType.DualFuel

            };
        }

    }
}
