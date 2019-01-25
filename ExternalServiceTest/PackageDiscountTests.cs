using ExternalServices.BO;
using ExternalServices.DTO;
using ExternalServices.Interfaces;
using Moq;
using NUnit.Framework;

namespace ExternalServiceTest
{
    [TestFixture]
    public class PackageDiscountTests
    {
        private PackageDiscount _packageDiscount;

        [SetUp]
        public void Init()
        {
        }

        [Test]
        public void PackageDiscounDualfuelBroadbandTypeBasicShouldReturn5PercentangeTest()
        {
            Mock<IPackageService> packageServiceMock = new Mock<IPackageService>();
            packageServiceMock.Setup(x => x.GetPackage(It.IsAny<string>())).Returns(GetBasicFuelTypePackage());

            _packageDiscount = new PackageDiscount(packageServiceMock.Object);
            var result = _packageDiscount.GetDiscount(It.IsAny<string>());

            Assert.AreEqual(result, 5);
        }

        [Test]
        public void PackageDiscounDualfuelBroadbandTypeHighSpeedShouldReturn10PercentangeTest()
        {
            Mock<IPackageService> packageServiceMock = new Mock<IPackageService>();
            packageServiceMock.Setup(x => x.GetPackage(It.IsAny<string>())).Returns(GetHighSpeedFuelTypePackage());

            _packageDiscount = new PackageDiscount(packageServiceMock.Object);
            var result = _packageDiscount.GetDiscount(It.IsAny<string>());

            Assert.AreEqual(result,10);
        }


        [Test]
        public void PackageDiscounOnlyGasBroadbandTypeHighSpeedShouldReturn5PercentangeTest()
        {
            Mock<IPackageService> packageServiceMock = new Mock<IPackageService>();
            packageServiceMock.Setup(x => x.GetPackage(It.IsAny<string>())).Returns(GetHighSpeedOnlyGasPackage());

            _packageDiscount = new PackageDiscount(packageServiceMock.Object);
            var result = _packageDiscount.GetDiscount(It.IsAny<string>());

            Assert.AreEqual(result, 5);
        }


        [Test]
        public void PackageDiscounOnlyElectricityBroadbandTypeHighSpeedShouldReturn5PercentangeTest()
        {
            Mock<IPackageService> packageServiceMock = new Mock<IPackageService>();
            packageServiceMock.Setup(x => x.GetPackage(It.IsAny<string>())).Returns(GetHighSpeedOnlyElectricityPackage());

            _packageDiscount = new PackageDiscount(packageServiceMock.Object);
            var result = _packageDiscount.GetDiscount(It.IsAny<string>());

            Assert.AreEqual(result, 5);
        }
        public Package GetBasicFuelTypePackage()
        {
            return new Package
            {
                BroadbandType = BroadbandType.Basic,
                FuelType = FuelType.DualFuel

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
        
        public Package GetHighSpeedOnlyGasPackage()
        {
            return new Package
            {
                BroadbandType = BroadbandType.HighSpeed,
                FuelType = FuelType.Gas

            };
        }

        public Package GetHighSpeedOnlyElectricityPackage()
        {
            return new Package
            {
                BroadbandType = BroadbandType.HighSpeed,
                FuelType = FuelType.Electricity

            };
        }


    }
}
