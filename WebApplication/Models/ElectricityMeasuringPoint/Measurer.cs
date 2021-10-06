using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Measurer: Record , IVerificatable
    {

            public string Number { get; set; }
            public DateTime VerificationDate { get; set; }
            public MeasurerType MeasurerType { get; set; }

    }
    public enum MeasurerType
    {
        TransformCurrent = 0,
        TransformVoltage = 1,
        EnergyMeter =2
    }
}
