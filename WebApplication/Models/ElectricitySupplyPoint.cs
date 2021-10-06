using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class ElectricitySupplyPoint: Record
    {
        public string Name { get; set; }
        public double MaxPower { get; set; }
        public CalculatingMeteringDevice calculatingMeteringDevice { get; set; }
    }
}
