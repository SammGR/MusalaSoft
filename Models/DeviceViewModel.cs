using System.Collections.Generic;

namespace Gateways.Models
{
    public class DeviceViewModel
    {
        public IEnumerable<Device> Devices { get; set; }
        public Device Device { get; set; }
        public IEnumerable<Gateway> Gateways { get; set; }
        public Gateway Gateway { get; set; }

    }
}