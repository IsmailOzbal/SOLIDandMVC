using ExternalServices.BO;
using ExternalServices.DTO;
using ExternalServices.Interfaces;
using Moq;
using NUnit.Framework;
using System;


namespace ExternalServiceTest
{
    [TestFixture]
    public class CustomerTypeDiscountTests
    {
        private CustomerTypeDiscount _customerTypeDiscount;

        [SetUp]
        public void Init()
        {
        }
        [Test]
        public void CustomerTypeGoldCustomerSpend1200ShouldReturn2PercentangeTest()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(GetFourYearsAccount());

            Mock<IAccountsService> accountServiceMock = new Mock<IAccountsService>();
            accountServiceMock.Setup(x => x.GetAccountHistory(It.IsAny<string>())).Returns(GetAccountHistorySpent1200());

            _customerTypeDiscount = new CustomerTypeDiscount(customerServiceMock.Object, accountServiceMock.Object);

            var result = _customerTypeDiscount.GetDiscount(It.IsAny<string>());

            Assert.AreEqual(result, 2);

        }
        [Test]
        public void CustomerTypeSilverCustomerSpend2200ShouldReturn2PercentangeTest()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(GetTwoYearsAccount());

            Mock<IAccountsService> accountServiceMock = new Mock<IAccountsService>();
            accountServiceMock.Setup(x => x.GetAccountHistory(It.IsAny<string>())).Returns(GetAccountHistorySpent2200());

            _customerTypeDiscount = new CustomerTypeDiscount(customerServiceMock.Object, accountServiceMock.Object);

            var result = _customerTypeDiscount.GetDiscount(It.IsAny<string>());

            Assert.AreEqual(result, 2);

        }
        [Test]
        public void CustomerTypeBronzeCustomerSpend3200ShouldReturn1PercentangeTest()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(GetOneYearsAccount());

            Mock<IAccountsService> accountServiceMock = new Mock<IAccountsService>();
            accountServiceMock.Setup(x => x.GetAccountHistory(It.IsAny<string>())).Returns(GetAccountHistorySpent3200());

            _customerTypeDiscount = new CustomerTypeDiscount(customerServiceMock.Object, accountServiceMock.Object);

            var result = _customerTypeDiscount.GetDiscount(It.IsAny<string>());

            Assert.AreEqual(result, 1);

        }
        private AccountHistory GetAccountHistorySpent3200()
        {
            return new AccountHistory()
            {
                YearlySpend = 3200M
            };
        }
        private AccountHistory GetAccountHistorySpent2200()
        {
            return new AccountHistory()
            {
                YearlySpend = 2200M
            };
        }
        private AccountHistory GetAccountHistorySpent1200()
        {
            return new AccountHistory()
            {
                YearlySpend = 1200M
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
        private CustomerAccount GetTwoYearsAccount()
        {
            return new CustomerAccount()
            {
                AccountId = "1",
                CreatedOn = DateTime.Now.AddYears(-2).AddMonths(-3)

            };
        }
        private CustomerAccount GetOneYearsAccount()
        {
            return new CustomerAccount()
            {
                AccountId = "1",
                CreatedOn = DateTime.Now.AddYears(-1).AddMonths(-3)

            };
        }
    }
}
