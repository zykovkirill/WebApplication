using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class Сonsumer : Record
    {
        public Сonsumer()
        {
            ElectricityMeasuringPoints = new List<ElectricityMeasuringPoint>();
            ElectricitySupplyPoints = new List<ElectricitySupplyPoint>();
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<ElectricityMeasuringPoint> ElectricityMeasuringPoints { get; set; }
        public List<ElectricitySupplyPoint> ElectricitySupplyPoints { get; set; }
    }
}
