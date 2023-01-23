using NUnit.Framework;
using Gateways.Models;
using System.Collections.Generic;

namespace Gateways.UnitTests.ModelsTests
{
    [TestFixture]
    public class UniqueUidTests
    {
        [Test]
        public void UniqUidInDb_GivenAUidThatAlreadyExistInDb_ReturnFlase()
        {
            var method = new UniqueUid();
            var newDevice = new Device
            {
                Id = 10,
                Uid = 05
            };
            var deviceInDb = new Device
            {
                Id = 11,
                Uid = 05
            };
            var devices = new List<Device> { deviceInDb };
            var result = method.UniqUidInDb(newDevice, devices);

            Assert.That(result, Is.False);
        }
        [Test]
        public void UniqUidInDb_GivenAUidThatNotExistInDb_ReturnTrue()
        {
            var method = new UniqueUid();
            var newDevice = new Device
            {
                Id = 10,
                Uid = 15
            };
            var deviceInDb = new Device
            {
                Id = 11,
                Uid = 05
            };
            var devices = new List<Device> { deviceInDb };
            var result = method.UniqUidInDb(newDevice, devices);

            Assert.That(result, Is.True);
        }
        [Test]
        public void UniqUidInDb_EditADeviceWithOutChangeTheUid_ReturnTrue()
        {
            var method = new UniqueUid();
            var deviceToEdit = new Device
            {
                Vendor="Samsung",
                Id = 10,
                Uid = 15
            };
            var deviceInDb1 = new Device
            {
                Id = 11,
                Uid = 05
            };
            var deviceInDb2 = new Device
            {
                Vendor="Apple",
                Id = 10,
                Uid = 15
            };
            var devices = new List<Device> { deviceInDb1,deviceInDb2 };
            var result = method.UniqUidInDb(deviceToEdit, devices);

            Assert.That(result, Is.True);
        }
        [Test]
        public void UniqUidInDb_EditADeviceAndChangingTheUidForOneUidThatNotExistInDb_ReturnTrue()
        {
            var method = new UniqueUid();
            var deviceToEdit = new Device
            {
                Vendor = "Samsung",
                Id = 10,
                Uid = 16
            };
            var deviceInDb1 = new Device
            {
                Id = 11,
                Uid = 05
            };
            var deviceInDb2 = new Device
            {
                Vendor = "Apple",
                Id = 10,
                Uid = 15
            };
            var devices = new List<Device> { deviceInDb1, deviceInDb2 };
            var result = method.UniqUidInDb(deviceToEdit, devices);

            Assert.That(result, Is.True);
        }
        [Test]
        public void UniqUidInDb_EditADeviceAndChangingTheUidForOneUidThatDoExistInDb_ReturnFalse()
        {
            var method = new UniqueUid();
            var deviceToEdit = new Device
            {
                Vendor = "Samsung",
                Id = 10,
                Uid = 05
            };
            var deviceInDb1 = new Device
            {
                Id = 11,
                Uid = 05
            };
            var deviceInDb2 = new Device
            {
                Vendor = "Apple",
                Id = 10,
                Uid = 15
            };
            var devices = new List<Device> { deviceInDb1, deviceInDb2 };
            var result = method.UniqUidInDb(deviceToEdit, devices);

            Assert.That(result, Is.False);
        }
    }
}
