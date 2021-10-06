using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Models;
using WebShared.Models;

namespace WebService
{
  public static class InitData
    {
        public static void InitDataBase(ApplicationContext db)
        {
            var device1 = new CalculatingMeteringDevice();
            var device2 = new CalculatingMeteringDevice();

            var electric1 = new Measurer { Number = "101N", MeasurerType = MeasurerType.EnergyMeter, VerificationDate = DateTime.UtcNow.AddDays(-2)};
            var electric2 = new Measurer { Number = "102N", MeasurerType = MeasurerType.EnergyMeter, VerificationDate = DateTime.UtcNow.AddDays(-3) };

            var transformVoltage1 = new Transformer { Number = "201R", MeasurerType = MeasurerType.TransformVoltage, VerificationDate = DateTime.UtcNow.AddDays(-4), RatioTransform = 1.5};
            var transformVoltage2 = new Transformer { Number = "202R", MeasurerType = MeasurerType.TransformVoltage, VerificationDate = DateTime.UtcNow.AddDays(-1), RatioTransform = 1.8 };

            var transformCurrent1 = new Transformer { Number = "501R", MeasurerType = MeasurerType.TransformCurrent, VerificationDate = DateTime.UtcNow.AddDays(-2), RatioTransform = 2.5 };
            var transformCurrent2 = new Transformer { Number = "502R", MeasurerType = MeasurerType.TransformCurrent, VerificationDate = DateTime.UtcNow.AddDays(-3), RatioTransform = 3.7 };

            var elPoint1 =  new ElectricityMeasuringPoint { Name = "TestElPoint1", ElectricEnergyMeter = electric1, TransformerCurrent = transformCurrent1, TransformerVoltage = transformVoltage1};
            var elPoint2 = new ElectricityMeasuringPoint { Name = "TestElPoint2", ElectricEnergyMeter = electric2, TransformerCurrent = transformCurrent2, TransformerVoltage = transformVoltage2 };

            var supPoint1 = new ElectricitySupplyPoint { Name = "TestSupPoint1", MaxPower = 200 };
            var supPoint2 = new ElectricitySupplyPoint { Name = "TestSupPoint2", MaxPower = 300 };

            var consumer1 = new Сonsumer { Name = "Consumer1", Address = "Address Consumer1" };
            var consumer2 = new Сonsumer { Name = "Consumer2", Address = "Address Consumer2" };

            var test = new Organization { Name = "Test0", Address = "TestAddress0" };
            var child = new Organization { Name = "Test", Address = "TestAddress" };
            var parent = new Organization { Name = "TestParent", Address = "TestAddressParent"};

            elPoint1.CalculatingMeteringDevices.Add(device1);
            elPoint1.CalculatingMeteringDevices.Add(device2);
            elPoint2.CalculatingMeteringDevices.Add(device2);
            elPoint2.CalculatingMeteringDevices.Add(device1);

            consumer1.ElectricitySupplyPoints.Add(supPoint2);
            consumer1.ElectricitySupplyPoints.Add(supPoint1);
            consumer2.ElectricitySupplyPoints.Add(supPoint2);
            consumer2.ElectricitySupplyPoints.Add(supPoint1);

            consumer1.ElectricityMeasuringPoints.Add(elPoint1);
            consumer1.ElectricityMeasuringPoints.Add(elPoint2);
            consumer2.ElectricityMeasuringPoints.Add(elPoint2);

            parent.ChildOrganizations.Add(child);
            parent.Сonsumers.Add(consumer1);
            parent.Сonsumers.Add(consumer2);

            db.CalculatingMeteringDevices.Add(device1);
            db.CalculatingMeteringDevices.Add(device2);

            db.Transformers.Add(transformVoltage1);
            db.Transformers.Add(transformVoltage1);
            db.Transformers.Add(transformCurrent2);
            db.Transformers.Add(transformCurrent1);

            db.Measurers.Add(electric1);
            db.Measurers.Add(electric2);

            db.ElectricityMeasuringPoints.Add(elPoint1);
            db.ElectricityMeasuringPoints.Add(elPoint2);

            db.ElectricitySupplyPoints.Add(supPoint1);
            db.ElectricitySupplyPoints.Add(supPoint2);

            db.Сonsumers.Add(consumer1);
            db.Сonsumers.Add(consumer2);

            db.Organizations.Add(child);
            db.Organizations.Add(parent);
            db.Organizations.Add(test);
            db.SaveChanges();
        }
    }
}
