using NUnit.Framework;
using Gateways.Controllers;
using System.Web.Mvc;
using Moq;
using Gateways.Models;

namespace Gateways.UnitTests.ControllersTests
{
    [TestFixture]
    public class DeviceControllerTests
    {
        private Mock<IDeviceStorage> _storage;
        private DeviceController _controller;

        [SetUp]
        public void SetUP() {
            _storage = new Mock<IDeviceStorage>();
            _controller = new DeviceController(_storage.Object);
        }

        [Test]
        public void Device_WhenCalled_GetTheDevicesFromDb()
        {
            var result = _controller.Devices();

            _storage.Verify(s => s.Devices());
        }

        [Test]
        public void Device_WhenCalled_VerifyThasNotEmpty()
        {
            var result = _controller.Devices() as ViewResult;

            Assert.IsNotNull(result);
        }

        [Test]
        public void Device_WhenCalled_ReturnsToTheViewDevice()
        {
            var result = _controller.Devices() as ViewResult;

            Assert.AreEqual("Devices", result.ViewName);
        }

        [Test]
        public void New_WhenCalled_ReturnsToDeviceFormView()
        {
            var result = _controller.New() as ViewResult;

            Assert.AreEqual("DeviceForm", result.ViewName);
        }

        [Test]
        public void Edit_WhenCalled_UseTheEditMethod()
        {
            var result = _controller.Edit(1);

            _storage.Verify(s => s.Edit(1));
        }
        [Test]
        public void Edit_WhenCalled_VerifyThasNotEmpty()
        {
            var result = _controller.Edit(1) as ViewResult;

            Assert.IsNotNull(result);
        }

        [Test]
        public void Edit_WhenCalled_ReturnsToTheDeviceFormView()
        {
            var result = _controller.Edit(1) as ViewResult;

            Assert.AreEqual("DeviceForm", result.ViewName);
        }

        [Test]
        public void Delete_WhenIsCalled_UseTheMethodDelete() {

            var result = _controller.Delete(2);

            _storage.Verify(s => s.DeleteDevice(2));
        }

        [Test]
        public void Delete_WhenIsCalled_ReturnsToTheDeviceView() {

            var result = _controller.Delete(1) as ViewResult;

            Assert.AreEqual("Devices", result.ViewName);

        }

        [Test]
        public void Delete_WhenCalled_VerifyThasNotEmpty()
        {
            var result = _controller.Delete(1) as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
