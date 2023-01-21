using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using Gateways.Models;
using Gateways.Dtos;
using System.Data.Entity;
using AutoMapper;

namespace Gateways.Controllers.Api
{
    public class GatewaysController : ApiController
    {
        private GatewayContext _context;
        public GatewaysController()
        {
            _context = new GatewayContext();
        }
    
        public IHttpActionResult GetGateways()
        {
            var gatewaysDto = _context.Gateways
                .Include(d => d.Devices)
                .ToList()
                .Select(Mapper.Map<Gateway, GatewayDto>);

            return Ok(gatewaysDto);
        }
   
        public GatewayDto GetGateway(int id)
        {
            var gateway = _context.Gateways.Include(d => d.Devices).SingleOrDefault(c => c.Id == id);
            if (gateway == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Gateway,GatewayDto>(gateway);
        }
    
        [HttpPost]
        public IHttpActionResult CreateGateway(GatewayDto gatewayDto)
        {
            var gateway = Mapper.Map<GatewayDto, Gateway>(gatewayDto);

            _context.Gateways.Add(gateway);

            gatewayDto.Id = gateway.Id;
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + gateway.Id),gatewayDto);           
        }

        [HttpPut]
        public IHttpActionResult UpdateGateway(int id, GatewayDto gatewayDto)
        {
            var gatewayInDb = _context.Gateways.SingleOrDefault(c => c.Id == id);

            if (gatewayInDb == null)
                return NotFound();

            Mapper.Map(gatewayDto, gatewayInDb);
            _context.SaveChanges();

            return Ok();
        }
      
        [HttpDelete]
        public void DeleteGateway(int id)
        {
            var gatewayInDb = _context.Gateways.SingleOrDefault(c => c.Id == id);

            if (gatewayInDb == null)
                  NotFound();

            _context.Gateways.Remove(gatewayInDb);
            _context.SaveChanges();
        }
    }
}
