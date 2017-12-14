using Api.Controllers.SubwayStops;
using BusinessServices;
using Ipreo.DomainModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class SubwayStopController : Controller
    {
        private ISubwayStopManager SubwayStopManager { get; set; }

        public SubwayStopController(ISubwayStopManager subwayStopManager)
        {
            SubwayStopManager = subwayStopManager;
        }

        // GET api/values
        [HttpGet]
        public ICollection<ApiSubwayStop> GetAll()
        {
            return Map(SubwayStopManager.GetAllSubwayStops());
        }

        private ICollection<ApiSubwayStop> Map(ICollection<SubwayStop> domainStops)
        {
            return domainStops.Select(stop => new ApiSubwayStop()
            {
                Id = stop.Id,
                Name = stop.Name,
                Latitude = stop.Latitude,
                Longitude = stop.Longitude
            })
            .ToList();
        }
        
    }
}
