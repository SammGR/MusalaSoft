using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Mvc;

namespace Gateways.Models
{
    public interface IGatewayStorage
    {
        Task<DeviceViewModel> Index();
    }

    public class GatewayStorage : Controller,IGatewayStorage
    {
        private GatewayContext _context;
        private Uri _url = new Uri("https://localhost:44325/api/gateways");
        private HttpClient _client = new HttpClient();

        public GatewayStorage()
        {
            _context = new GatewayContext();
        }

        public async Task<DeviceViewModel> Index()
        {
            var json = await _client.GetStringAsync(_url);
            var gateway = JsonConvert.DeserializeObject<List<Gateway>>(json);

            var viewModel = new DeviceViewModel
            {
                Gateways = gateway.ToList()
            };           
                   
            return viewModel;
        }

    }
}