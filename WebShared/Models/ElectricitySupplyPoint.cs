
namespace WebShared.Models
{
    public class ElectricitySupplyPoint : Record
    {
        public string Name { get; set; }
        public double MaxPower { get; set; }
        public CalculatingMeteringDevice CalculatingMeteringDevice { get; set; }
    }
}
