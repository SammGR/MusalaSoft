using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using Gateways.Models;
using System.Data.Entity;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;


namespace Gateways.Controllers
{
    public class GatewayController : Controller
    {
        private GatewayContext _context;
        private  Uri _url = new Uri("https://localhost:44325/api/gateways");
        private HttpClient _client = new HttpClient();

        public GatewayController()
        {
            _context = new GatewayContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public async Task<ActionResult> Gateways()
        {          
            var json = await _client.GetStringAsync(_url);  
            var gateway = JsonConvert.DeserializeObject<List<Gateway>>(json);             

            return View(gateway);
        }

        public ActionResult New()
        {
            var viewModel = new Gateway();           
            return View("NewGateway", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Gateway gateway)
        {
            if (!ModelState.IsValid)
            {
                var view = (gateway.Id == 0) ? "NewGateway" : "GatewayForm";
                var viewModel = _context.Gateways.Include(d => d.Devices).SingleOrDefault(g => g.Id == gateway.Id);                

                if (gateway.Id == 0)
                {
                    return View(view, viewModel);
                }

                var gatewayEdit = _context.Gateways.Include(d => d.Devices).SingleOrDefault(g => g.Id == gateway.Id);
                var deviceModel = new DeviceViewModel { Gateway = gatewayEdit, Devices = gatewayEdit.Devices };

                return View(view, deviceModel);
            }

            if (gateway.Id==0)
            {   
               
               var post = _client.PostAsJsonAsync<Gateway>(_url, gateway);
               post.Wait();               
            }
            else
            {
                var put = _client.PutAsJsonAsync<Gateway>(_url+"/"+gateway.Id, gateway);
                put.Wait();
            }
            return RedirectToAction("Gateways", "Gateway");
        }

        public ActionResult Edit(int id) {

            var gateway = _context.Gateways.Include(d => d.Devices).SingleOrDefault(g => g.Id == id);

            if (gateway == null)
                HttpNotFound();

            var deviceModel = new DeviceViewModel
            {
                Gateway = gateway,
                Devices = gateway.Devices
            };

            return View("GatewayForm", deviceModel);
        
        }

        public ActionResult Delete(int id)
        {        
            var delete = _client.DeleteAsync(_url + "/" + id);
            delete.Wait();

            return RedirectToAction("Gateways", "Gateway");
        }

    }
}