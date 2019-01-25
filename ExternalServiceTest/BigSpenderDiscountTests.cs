using ExternalServices.BO;
using ExternalServices.DTO;
using ExternalServices.Interfaces;
using Moq;
using NUnit.Framework;
using System;

namespace ExternalServiceTest
{
    [TestFixture]
    public class BigSpenderDiscountTests
    {
        private BigSpenderDiscount _bigSpenderDiscount;
   
        [SetUp]
        public void Init()
        {
        }

        [Test]
        public void BigSpender600ShouldReturn25PercentangeTest()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(GetTwoYearsAccount());

            Mock<IAccountsService> accountServiceMock = new Mock<IAccountsService>();
            accountServiceMock.Setup(x => x.GetAccountHistory(It.IsAny<string>())).Returns(GetAccountHistorySpent600());

            _bigSpenderDiscount = new BigSpenderDiscount(customerServiceMock.Object, accountServiceMock.Object);

            var result = _bigSpenderDiscount.GetDiscount(It.IsAny<string>());

            Assert.AreEqual(result, 0.25M);

        }

        [Test]
        public void BigSpender1500ShouldReturn5PercentangeTest()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(GetTwoYearsAccount());

            Mock<IAccountsService> accountServiceMock = new Mock<IAccountsService>();
            accountServiceMock.Setup(x => x.GetAccountHistory(It.IsAny<string>())).Returns(GetAccountHistorySpent1500());

            _bigSpenderDiscount = new BigSpenderDiscount(customerServiceMock.Object, accountServiceMock.Object);

            var result = _bigSpenderDiscount.GetDiscount(It.IsAny<string>());

            Assert.AreEqual(result, 0.5M);

        }


        [Test]
        public void BigSpender2500ShouldReturn1PercentangeTest()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(GetTwoYearsAccount());

            Mock<IAccountsService> accountServiceMock = new Mock<IAccountsService>();
            accountServiceMock.Setup(x => x.GetAccountHistory(It.IsAny<string>())).Returns(GetAccountHistorySpent2500);

            _bigSpenderDiscount = new BigSpenderDiscount(customerServiceMock.Object, accountServiceMock.Object);

            var result = _bigSpenderDiscount.GetDiscount(It.IsAny<string>());

            Assert.AreEqual(result,1);

        }

        [Test]
        public void BigSpender6000ShouldReturn2PercentangeTest()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(GetTwoYearsAccount());

            Mock<IAccountsService> accountServiceMock = new Mock<IAccountsService>();
            accountServiceMock.Setup(x => x.GetAccountHistory(It.IsAny<string>())).Returns(GetAccountHistorySpent6000());

            _bigSpenderDiscount = new BigSpenderDiscount(customerServiceMock.Object, accountServiceMock.Object);

            var result = _bigSpenderDiscount.GetDiscount(It.IsAny<string>());

            Assert.AreEqual(result, 2);

        }

        private AccountHistory GetAccountHistorySpent600()
        {
            return new AccountHistory()
            {
                YearlySpend = 600M
            };
        }

        private AccountHistory GetAccountHistorySpent1500()
        {
            return new AccountHistory()
            {
                YearlySpend = 1500M
            };
        }

        private AccountHistory GetAccountHistorySpent2500()
        {
            return new AccountHistory()
            {
                YearlySpend = 2500M
            };
        }

        private AccountHistory GetAccountHistorySpent6000()
        {
            return new AccountHistory()
            {
                YearlySpend = 6000M
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
    }
}
