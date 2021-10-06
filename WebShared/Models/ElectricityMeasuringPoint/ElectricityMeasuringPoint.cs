using System.Collections.Generic;


namespace WebShared.Models
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
        public List<CalculatingMeteringDevice> CalculatingMeteringDevices { get; set; }

    }
}
