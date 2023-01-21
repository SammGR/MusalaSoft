using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Gateways.Models
{
    public class UniqSerialNumber : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            GatewayContext _context = new GatewayContext();
            var gateway = (Gateway)validationContext.ObjectInstance;
            var gateways = _context.Gateways.ToList();

            if (gateway.Id == 0 && gateway.Name == null)
            {
                return ValidationResult.Success;
            }

            else if (gateway.Id == 0)
            {
                return UniqSerialNumberInDb(gateway, gateways)
                    ? ValidationResult.Success
                    : new ValidationResult("The Serial Number already exists.");
            }

            else
            {
                return UniqSerialNumberInDb(gateway, gateways)
                     ? ValidationResult.Success
                     : new ValidationResult("The Serial Number already exists.");
            }
        }

        public bool UniqSerialNumberInDb(Gateway gateway, List<Gateway> gateways)
        {
            for (int i = 0; i < gateways.Count; i++)
            {
                if (gateway.SerialNumber == gateways[i].SerialNumber && gateway.Id != gateways[i].Id)
                {
                    return false;
                }
            }
            return true;
        }

    }
}