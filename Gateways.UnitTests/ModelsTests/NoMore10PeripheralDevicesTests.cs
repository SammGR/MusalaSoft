using NUnit.Framework;
using Gateways.Models;

namespace Gateways.UnitTests.ModelsTests
{
    [TestFixture]
    public class NoMore10PeripheralDevicesTests
    {
        [Test]
        [TestCase(6, true)]
        [TestCase(10, true)]
        [TestCase(12, false)]
        public void NoMoreTenDevices_CheckTheDevicesAreLessThanTenPeriphericalDevices_ReturnsTrue(int value, bool expectedResult)
        {
            var cantDevices = new NoMore10PeripheralDevices();

            var result = cantDevices.NoMoreTenDevices(value);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
