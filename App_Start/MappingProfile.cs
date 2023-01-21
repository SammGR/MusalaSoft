using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Gateways.Models;
using Gateways.Dtos;

namespace Gateways.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {

            Mapper.CreateMap<Gateway, GatewayDto>();
            Mapper.CreateMap<GatewayDto, Gateway>();
            Mapper.CreateMap<Device, DeviceDto>();
            
        }
    }
}