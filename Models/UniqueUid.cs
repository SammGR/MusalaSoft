using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Gateways.Models
{
    public class UniqueUid : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            GatewayContext _context = new GatewayContext();
            var device = (Device)validationContext.ObjectInstance;           
            var devices = _context.Devices.ToList();

            if (device.Id == 0 && device.Vendor == null)
            {
                return  ValidationResult.Success;
            }

            else if (device.Id == 0)
            {
                return UniqUidInDb(device, devices) 
                    ? ValidationResult.Success 
                    : new ValidationResult("The Uid property already exists.");
            }

            else {
                return UniqUidInDb(device, devices)
                     ? ValidationResult.Success
                     : new ValidationResult("The Uid property already exists.");
            }   
        }

        public bool UniqUidInDb(Device device, List<Device> devices) {
                       
            for (int i = 0; i < devices.Count; i++)
            {
                if (device.Uid == devices[i].Uid && device.Id != devices[i].Id)
                {
                    return false;
                }
            }
            return true;
        }
    }
}