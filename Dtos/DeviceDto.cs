using System;

namespace Gateways.Dtos
{
    public class DeviceDto
    {
        public int Id { get; set; }
        public int Uid { get; set; }       
        public string Vendor { get; set; }        
        public DateTime DateCreated { get; set; }       
        public bool IsOnline { get; set; }        
        public int GatewayId { get; set; }
    }
}