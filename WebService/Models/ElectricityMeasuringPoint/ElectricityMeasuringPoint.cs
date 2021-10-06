using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class ElectricityMeasuringPoint : Record
    {
        public ElectricityMeasuringPoint()
        {
            CalculatingMeteringDevices = new List<CalculatingMeteringDevice>(); 
        }
        public string Name { get; set; }

        public Measurer ElectricEnergyMeter { get; set; }

        public Transformer TransformerVoltage { get; set; }
        public Transformer TransformerCurrent { get; set; }
        public List<CalculatingMeteringDevice> CalculatingMeteringDevices {get; set;}

    }
}
