using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Gateways.Models
{
    public class Gateway
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Serial Number field is required.")]
        [Display(Name = "Serial Number")]
        [UniqSerialNumber]
        public string SerialNumber { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [MaxLength(300)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Ip Address field is required.")]
        [Display(Name = "Ip Address")]
        [ValidarIpV4]
        public string Ipv4Address { get; set; }   
        
        public IList<Device> Devices { get; set; }

        public Gateway() { Id = 0; }

        public Gateway(Gateway gateway) {

            Id = gateway.Id;
            SerialNumber = gateway.SerialNumber;
            Name = "";
            Ipv4Address = gateway.Ipv4Address;        
        }
    }
}