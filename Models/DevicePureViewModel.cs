using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gateways.Models
{
    public class DevicePureViewModel
    {
        public int? Id { get; set; }

        [UniqueUid]
        [Required]
        public int? Uid { get; set; }

        [Required]
        public string Vendor { get; set; }

        [Required]
        public bool IsOnline { get; set; }

        public IEnumerable<Gateway> Gateways { get; set; }

        [Display(Name = "Gateway")]
        [Required]
        [NoMore10PeripheralDevices]
        public int GatewayId { get; set; }

        public DevicePureViewModel() { Id = 0; }

        public DevicePureViewModel(Device device) {
            Id = device.Id;            
            Vendor = device.Vendor;
            IsOnline = device.IsOnline;
            GatewayId = device.GatewayId;       
        }
    }
}