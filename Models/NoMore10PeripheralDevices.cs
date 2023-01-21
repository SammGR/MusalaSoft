using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Gateways.Models
{
    public class NoMore10PeripheralDevices : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            GatewayContext _context = new GatewayContext();
            var device = (Device)validationContext.ObjectInstance;

            if (device.GatewayId == 0)
            {
                return ValidationResult.Success;
            }
            else if (device.Id != 0) {
                return ValidationResult.Success;
            }
            else
            {
                var gateway = _context.Gateways.
                        Include(d => d.Devices).
                        SingleOrDefault(g => g.Id == device.GatewayId);

                if (NoMoreTenDevices(gateway.Devices.Count))
                    return ValidationResult.Success;
                return new ValidationResult("Each Gateway can only have a maximum of 10 devices.");
            }
        }

        public bool NoMoreTenDevices(int cant) 
        {
            if (cant <= 10)
                return true;
            return false;
        }        
    }
}