using Data;
using Ipreo.DomainModel;
using System.Collections.Generic;

namespace BusinessServices
{
    public class SubwayStopManager : ISubwayStopManager
    {
        private ISubwayStopRepository SubwayStopRepository { get; set; }

        public SubwayStopManager(ISubwayStopRepository stopRepo)
        {
            SubwayStopRepository = stopRepo;
        }

        public ICollection<SubwayStop> GetAllSubwayStops()
        {
            return SubwayStopRepository.GetAll();
        }        
    }
}
