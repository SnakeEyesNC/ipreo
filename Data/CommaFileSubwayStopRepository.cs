using Data;
using Ipreo.DomainModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ipreo.Data
{
    public class CommaFileSubwayStopRepository : ISubwayStopRepository
    {
        private string fullFilePath;
        private ICollection<SubwayStop> _subwayStops;

        private const int lineIndexId = 0;
        private const int lineIndexName = 2;
        private const int lineIndexLatitude = 4;
        private const int lineIndexLongitude = 5;
        private const int lineIndexParentStation = 9;

        private ICollection<SubwayStop> SubwayStops
        {
            get
            {
                if (_subwayStops == null)
                {
                    ReadDataFromFile();
                }

                return _subwayStops;
            }
        }

        public CommaFileSubwayStopRepository(string fullDataFilePath = null)
        {
            if (fullDataFilePath != null)
            {
                fullFilePath = fullDataFilePath;
            }
            else
            {
                string runningDirPath = Directory.GetCurrentDirectory();
                fullFilePath = Path.Combine(runningDirPath, "DataFiles", @"stops.txt");
            }
            
        }

        public ICollection<SubwayStop> GetAll()
        {
            return SubwayStops;
        }

        public SubwayStop Get(string id)
        {
            return SubwayStops.FirstOrDefault(s => s.Id == id);
        }

        private void ReadDataFromFile()
        {
            var lines = File.ReadAllLines(fullFilePath);
            _subwayStops = (from line in lines.Skip(1)
                            let lineData = line.Split(new[] { ',' }, StringSplitOptions.None).ToArray()
                    where string.IsNullOrEmpty(lineData[lineIndexParentStation]) // Don't get children stop rows.  Redundant for our needs.
                    select new SubwayStop()
                    {
                        Id = lineData[lineIndexId],
                        Name = lineData[lineIndexName],
                        Latitude = Convert.ToDouble(lineData[lineIndexLatitude]),
                        Longitude = Convert.ToDouble(lineData[lineIndexLongitude])
                    })
                .ToList();
        }
    }
}
