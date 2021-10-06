using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class CalculatingMeteringDevice:Record
    {
        public CalculatingMeteringDevice()
        {
            ElectricityMeasuringPoints = new List<ElectricityMeasuringPoint>();
        }
        public List<ElectricityMeasuringPoint> ElectricityMeasuringPoints { get; set; }
    }
}
