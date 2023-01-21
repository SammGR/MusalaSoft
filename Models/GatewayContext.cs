using System.Data.Entity;

namespace Gateways.Models
{
    public class GatewayContext : DbContext
    {
        public DbSet<Gateway> Gateways { get; set; }

        public DbSet<Device> Devices { get; set; }

        public GatewayContext()
            :base("name=GatewayConexion")
        {

        }
    }
}