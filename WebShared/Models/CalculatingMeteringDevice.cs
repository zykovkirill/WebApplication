using System.Collections.Generic;

namespace WebShared.Models
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
