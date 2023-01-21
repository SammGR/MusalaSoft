using System.Web.Mvc;
using Gateways.Models;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;


namespace Gateways.Controllers
{
    public class DeviceController : Controller
    {
        private readonly  IDeviceStorage _storage;
        public DeviceController(IDeviceStorage storage)
        {
            _storage = storage;
        }
       
        public  ActionResult Devices()
        {
            var viewModel = _storage.Devices();
            return View("Devices",viewModel);
        }
        [HttpPost]   
        [ValidateAntiForgeryToken]
        public ActionResult Save(Device device)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = _storage.ValidateModel(device);
                return View("DeviceForm", viewModel);
            }        

            _storage.Save(device);
            return RedirectToAction("Devices", "Device");
        }

        public ActionResult New() 
        {
            var viewModel = _storage.New();   
            
            return View("DeviceForm", viewModel);
        }
       
        [HttpPut]
        public ActionResult Edit(int id)
        {
            var viewModel = _storage.Edit(id);
            return View("DeviceForm", viewModel);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var viewModel = _storage.DeleteDevice(id);
            return View("Devices",viewModel);
        }
    }
}
