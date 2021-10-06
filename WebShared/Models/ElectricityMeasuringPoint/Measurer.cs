using System;

namespace WebShared.Models
{
    public class Measurer : Record, IVerificatable
    {
        public string Number { get; set; }
        public DateTime VerificationDate { get; set; }
        public MeasurerType MeasurerType { get; set; }

    }

    public class Transformer : Measurer
    {
        public double RatioTransform { get; set; }
    }
    public enum MeasurerType
    {
        TransformCurrent = 0,
        TransformVoltage = 1,
        EnergyMeter = 2
    }
}
