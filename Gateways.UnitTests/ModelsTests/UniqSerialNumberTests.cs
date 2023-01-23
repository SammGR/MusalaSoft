using NUnit.Framework;
using Gateways.Models;
using System.Collections.Generic;

namespace Gateways.UnitTests.ModelsTests
{
    [TestFixture]
    public class UniqSerialNumberTests
    {
        [Test]
        public void UniqSerialNumberInDb_GivenASerialNumberThatAlreadyExistInDb_ReturnFlase() 
        {
            var method = new UniqSerialNumber();
            var newGateway = new Gateway
            {
                Id = 87,
                SerialNumber = "002ab3x"
            };
            var gatewayInDb = new Gateway
            {
                Id = 101,
                SerialNumber = "002ab3x"
            };
            var gateways = new List<Gateway> { gatewayInDb };
            var result = method.UniqSerialNumberInDb(newGateway, gateways);

            Assert.That(result, Is.False);
        }

        [Test]
        public void UniqSerialNumberInDb_GivenASerialNumberThatNotExistInDb_ReturnTrue()
        {
            var method = new UniqSerialNumber();
            var newGateway = new Gateway
            {
                Id = 87,
                SerialNumber = "kl12aX"
            };
            var gatewayInDb = new Gateway
            {
                Id = 101,
                SerialNumber = "002ab3x"
            };
            var gateways = new List<Gateway> { gatewayInDb };
            var result = method.UniqSerialNumberInDb(newGateway, gateways);

            Assert.That(result, Is.True);

        }

        [Test]
        public void UniqSerialNumberInDb__EditAGatewayWithOutChangeTheSerialNumber_ReturnTrue()
        {
            var method = new UniqSerialNumber();
            var gatewayToEdit = new Gateway
            {
                Name="Node_One",
                Id = 87,
                SerialNumber = "002ab3x"
            };
            var gatewayInDb1 = new Gateway
            {
                Name = "Node_Two",
                Id = 87,
                SerialNumber = "002ab3x"
            };
            var gatewayInDb2 = new Gateway
            {                
                Id = 101,
                SerialNumber = "ncq32"
            };
            var gateways = new List<Gateway> { gatewayInDb1,gatewayInDb2 };
            var result = method.UniqSerialNumberInDb(gatewayToEdit, gateways);

            Assert.That(result, Is.True);
        }

        [Test]
        public void UniqSerialNumberInDb__EditAGatewayAndChangingTheSerialNumberForOneSerialNumberThatNotExistInDb_ReturnTrue()
        {
            var method = new UniqSerialNumber();
            var gatewayToEdit = new Gateway
            {                
                Id = 87,
                SerialNumber = "145c"
            };
            var gatewayInDb1 = new Gateway
            {                
                Id = 87,
                SerialNumber = "002ab3x"
            };
            var gatewayInDb2 = new Gateway
            {
                Id = 101,
                SerialNumber = "ncq32"
            };
            var gateways = new List<Gateway> { gatewayInDb1, gatewayInDb2 };
            var result = method.UniqSerialNumberInDb(gatewayToEdit, gateways);

            Assert.That(result, Is.True);
        }

        [Test]
        public void UniqSerialNumberInDb__EditAGatewayAndChangingTheSerialNumberForOneSerialNumberThatDoExistInDb_ReturnFalse()
        {
            var method = new UniqSerialNumber();
            var gatewayToEdit = new Gateway
            {
                Id = 87,
                SerialNumber = "152lk"
            };
            var gatewayInDb1 = new Gateway
            {
                Id = 87,
                SerialNumber = "002ab3x"
            };           
            var gatewayInDb2 = new Gateway
            {
                Id = 874,
                SerialNumber = "152lk"
            };
            var gateways = new List<Gateway> { gatewayInDb1, gatewayInDb2 };
            var result = method.UniqSerialNumberInDb(gatewayToEdit, gateways);

            Assert.That(result, Is.False);
        }

    }
}
