using Ipreo.DomainModel;
using System.Collections.Generic;

namespace BusinessServices
{
    public interface ISubwayStopManager
    {
        ICollection<SubwayStop> GetAllSubwayStops();
    }
}
