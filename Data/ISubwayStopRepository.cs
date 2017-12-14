using Ipreo.DomainModel;
using System.Collections.Generic;

namespace Data
{
    public interface ISubwayStopRepository
    {
        ICollection<SubwayStop> GetAll();
        SubwayStop Get(string id);
    }
}
