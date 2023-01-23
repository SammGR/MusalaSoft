using System;
using NUnit.Framework;
using Gateways.Models;
using System.Collections.Generic;

namespace Gateways.UnitTests.ModelsTests
{
    [TestFixture]
    public class ValidarIpV4Tests
    { 
        [Test]
        [TestCase("10.5.2.15", true)]
        [TestCase("10.5.257.15", false)]
        [TestCase("10.5.2", false)]
        public void ValidarIpV4_GivenAnInvalidIpV4_ReturnsFalse(string ip, bool expectedResult)
        {
            var method = new ValidarIpV4();
            string invalidIp = ip;

            var result = method.isValid(invalidIp);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ValidarIpV4_GivenAGatewayWithAnIpTahtAllreadyExistInDb_ReturnFalse()
        {
            var method = new ValidarIpV4();
            var newGateway = new Gateway
            {             
                Id = 10,
                Ipv4Address = "10.5.2.14",                
            };
            var gatewayInDb = new Gateway
            {               
                Id = 11,
                Ipv4Address = "10.5.2.14",              
            };
            var gateways = new List<Gateway> { gatewayInDb };

            var result = method.uniqueIpV4(newGateway, gateways);

            Assert.That(result, Is.False);
        }

        [Test]
        public void ValidarIpV4_GivenAGatewayWithAnIpTahtNotExistInDb_ReturnTrue()
        {
            var method = new ValidarIpV4();
            var newGateway = new Gateway
            {                
                Id = 10,
                Ipv4Address = "10.5.2.15",               
            };
            var gatewayInDb = new Gateway
            {            
                Id = 11,
                Ipv4Address = "10.5.2.14",               
            };
            var gateways = new List<Gateway> { gatewayInDb };

            var result = method.uniqueIpV4(newGateway, gateways);

            Assert.That(result, Is.True);
        }

        [Test]
        public void ValidarIpV4_GivenAGatewayToEditWithAnIpTahtExistInDbAndTheSameId_ReturnTrue()
        {
            var method = new ValidarIpV4();
            var gatewayToEdit = new Gateway
            {               
                Id = 10,
                Ipv4Address = "10.5.2.15",              
            };
            var gatewayInDb = new Gateway
            {               
                Id = 10,
                Ipv4Address = "10.5.2.15",              
            };
            var gateways = new List<Gateway> {gatewayInDb };

            var result = method.uniqueIpV4(gatewayToEdit, gateways);

            Assert.That(result, Is.True);
        }

        [Test]
        public void ValidarIpV4_GivenAGatewayToEditAndChangeTheIpToAnotherTahtAlreadyExistInDb_ReturnFalse()
        {
            var method = new ValidarIpV4();
            var gatewayToEdit = new Gateway
            {                
                Id = 10,
                Ipv4Address = "10.5.2.25",              
            };
            var gatewayInDb1 = new Gateway
            {              
                Id = 10,
                Ipv4Address = "10.5.2.15",                
            };
            var gatewayInDb2 = new Gateway
            {               
                Id = 14,
                Ipv4Address = "10.5.2.25",               
            };
            var gateways = new List<Gateway> { gatewayInDb1,gatewayInDb2 };

            var result = method.uniqueIpV4(gatewayToEdit, gateways);

            Assert.That(result, Is.False);
        }

    }
}
