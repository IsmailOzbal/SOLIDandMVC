using ExternalServices.BO;
using ExternalServices.DTO;
using ExternalServices.Interfaces;
using Moq;
using NUnit.Framework;
using System;


namespace ExternalServiceTest
{
    [TestFixture]
    public class LongServiceDiscountTests
    {
        private LongServiceDiscount _longSeviceDiscount;

        [SetUp]
        public void Init()
        {
        }

        [Test]
        public void LongServiceOneYearShouldReturn25PercentangeTest()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(GetOneYearsAccount());

            _longSeviceDiscount = new LongServiceDiscount(customerServiceMock.Object);
            var result = _longSeviceDiscount.GetDiscount(It.IsAny<string>());

            Assert.AreEqual(result, 0.25M);
        }


        [Test]
        public void LongServiceTwoYearShouldReturn5PercentangeTest()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(GetTwoYearsAccount());

            _longSeviceDiscount = new LongServiceDiscount(customerServiceMock.Object);
            var result = _longSeviceDiscount.GetDiscount(It.IsAny<string>());

            Assert.AreEqual(result, 0.5M);
        }


        [Test]
        public void LongServiceFourYearShouldReturn1PercentangeTest()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(GetFourYearsAccount());

            _longSeviceDiscount = new LongServiceDiscount(customerServiceMock.Object);
            var result = _longSeviceDiscount.GetDiscount(It.IsAny<string>());

            Assert.AreEqual(result, 1);
        }

        private CustomerAccount GetTwoYearsAccount()
        {
            return new CustomerAccount()
            {
                AccountId = "1",
                CreatedOn = DateTime.Now.AddYears(-2)

            };
        }

        private CustomerAccount GetOneYearsAccount()
        {
            return new CustomerAccount()
            {
                AccountId = "1",
                CreatedOn = DateTime.Now.AddYears(-1)

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
    }
}
