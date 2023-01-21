using System;
using System.Linq;
using System.Web.Mvc;



namespace Gateways.Models
{
    public interface IDeviceStorage
    {
        DeviceViewModel DeleteDevice(int id);
        DeviceViewModel Devices();
        DevicePureViewModel ValidateModel(Device device);
        void Save(Device device);
        DevicePureViewModel New();
        DevicePureViewModel Edit(int id);
    }

    public class DeviceStorage :Controller, IDeviceStorage
    {
        private GatewayContext _context;
        
        public DeviceStorage()
        {
            _context = new GatewayContext();
        }
        public DeviceViewModel DeleteDevice(int id)
        {
            var device = _context.Devices.SingleOrDefault(c => c.Id == id);
            if (device == null) return new DeviceViewModel();

            _context.Devices.Remove(device);
            _context.SaveChanges();

            var devices = _context.Devices.ToList();
            var viewModel = new DeviceViewModel
            {
                Devices = devices,
                Gateways = _context.Gateways.ToList()
            };
            return viewModel;
        }

        public DeviceViewModel Devices() {


            var devices = _context.Devices.ToList();
            var deviceModel = new DeviceViewModel
            {
                Devices = devices,
                Gateways = _context.Gateways.ToList()
            };
            return deviceModel;
        }

        public void Save(Device device) 
        {            
            device.DateCreated = DateTime.Now;
            if (device.Id == 0)
                _context.Devices.Add(device);
            else
            {
                var deviceInDb = _context.Devices.Single(c => c.Id == device.Id);
                deviceInDb.Vendor = device.Vendor;
                deviceInDb.Uid = device.Uid;
                deviceInDb.DateCreated = device.DateCreated;
                deviceInDb.IsOnline = device.IsOnline;
                deviceInDb.GatewayId = device.GatewayId;
            }
            _context.SaveChanges();
        }

        public DevicePureViewModel ValidateModel(Device device) {

            device.DateCreated = DateTime.Now;

            var viewModel = new DevicePureViewModel(device)
            {
                Gateways = _context.Gateways.ToList(),
            };

            return viewModel;
        }

        public DevicePureViewModel New() {

            var viewModel = new DevicePureViewModel
            {
                Gateways = _context.Gateways.ToList(),
            };
            return viewModel;
        }

        public DevicePureViewModel Edit(int id) {

            var device = _context.Devices.SingleOrDefault(c => c.Id == id);

            if (device == null) return new DevicePureViewModel();

            var viewModel = new DevicePureViewModel(device)
            {
                Uid = device.Uid,
                Gateways = _context.Gateways.ToList()
            };

            return viewModel;
        }
             
    }
}