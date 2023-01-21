using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Gateways.Models
{
    public class Device
    {
        public int Id { get; set; }  

        [UniqueUid]
        [Required(ErrorMessage = "The Uid field is required.")]
        public int Uid { get; set; }

        [Required(ErrorMessage = "The Vendor field is required.")]
        [MaxLength(300)]
        public string Vendor { get; set; }

        [Required]       
        public DateTime DateCreated { get; set; }

        [Required]
        public bool IsOnline { get; set; }

        [ForeignKey("Gateway")]
        [Display(Name ="Gateway")]
        [NoMore10PeripheralDevices]
        [Required(ErrorMessage = "The Gateway field is required.")]
        public int GatewayId { get; set; }

        public virtual Gateway Gateway { get; set; }

    }

}