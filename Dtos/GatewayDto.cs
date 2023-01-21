using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gateways.Dtos
{
    public class GatewayDto
    {
        public int Id { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }
        [Required]
        public string Ipv4Address { get; set; }
        [Required]
        public IList<DeviceDto> Devices { get; set; }
       
    }
}