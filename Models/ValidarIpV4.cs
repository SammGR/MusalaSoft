using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;



namespace Gateways.Models
{
    public class ValidarIpV4 : ValidationAttribute
    {   
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            GatewayContext _context = new GatewayContext();
            var gateway = (Gateway)validationContext.ObjectInstance;
            var gateways = _context.Gateways.ToList();

            if (gateway.Ipv4Address != null && isValid(gateway.Ipv4Address))
            {

                if (gateway.Id == 0 && gateway.Ipv4Address == null)
                {
                    return ValidationResult.Success;
                }
                else if (gateway.Id == 0)
                {
                    return (uniqueIpV4(gateway, gateways) == true) 
                        ? ValidationResult.Success 
                        : new ValidationResult("The ip address already exists.");                   
                }
                else
                {
                    return (uniqueIpV4(gateway, gateways) == true) 
                        ? ValidationResult.Success 
                        : new ValidationResult("The ip address already exists.");
                }
            }
            else
            {
                return new ValidationResult("The ip address is not valid.");
            }
        }

        public bool uniqueIpV4(Gateway gateway,IList<Gateway> gateways) {

            for (int i = 0; i < gateways.Count; i++)
            {
                if (gateway.Ipv4Address == gateways[i].Ipv4Address && gateway.Id != gateways[i].Id)
                {
                    return false;
                }
            }
            return true;
        }

        public bool isValid(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }

            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }
            byte tempForParsing;
            return splitValues.All(r => byte.TryParse(r, out tempForParsing));            
        }
             
    }
}