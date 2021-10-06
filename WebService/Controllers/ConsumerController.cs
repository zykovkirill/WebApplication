using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Models;
using Microsoft.EntityFrameworkCore;
using WebShared.Models;

namespace WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsumerController : ControllerBase
    {
        

        private readonly ILogger<ConsumerController> _logger;
        private ApplicationContext _db;
        public ConsumerController(ILogger<ConsumerController> logger, ApplicationContext context)
        {
            _logger = logger;
            _db = context;
        }

        [HttpGet]
        public IEnumerable<Сonsumer> Get()
        {
            var result = _db.Сonsumers;
            return result;
        }

        [HttpGet("Measurers")]
        public IEnumerable<IVerificatable> Get(string id, bool isCurrent, bool isVoltage, bool isMeasurer)
        {
            var measurers = new List<IVerificatable>();
            if (isCurrent)
            {
                var transformerCurrent = _db.Сonsumers.Include(c => c.ElectricityMeasuringPoints)
                    .ThenInclude(c => c.TransformerCurrent)
                    .FirstOrDefault(c => c.Id == id)?.ElectricityMeasuringPoints?
                    .Where(e => e.TransformerCurrent.VerificationDate <= DateTime.Now)?
                    .Select(e => e.TransformerCurrent)
                    .ToList();
                measurers.AddRange(transformerCurrent);
            }
            if (isVoltage)
            {
                var transformerVoltage = _db.Сonsumers.Include(c => c.ElectricityMeasuringPoints)
                    .ThenInclude(c => c.TransformerVoltage)
                    .FirstOrDefault(c => c.Id == id)?.ElectricityMeasuringPoints?
                    .Where(e => e.TransformerVoltage.VerificationDate <= DateTime.Now)?
                    .Select(e => e.TransformerVoltage)
                    .ToList();
                measurers.AddRange(transformerVoltage);
            }
            if (isMeasurer)
            {
                var ElectricEnergyMeter = _db.Сonsumers.Include(c => c.ElectricityMeasuringPoints)
                    .ThenInclude(c => c.ElectricEnergyMeter)
                    .FirstOrDefault(c => c.Id == id)?.ElectricityMeasuringPoints?
                    .Where(e => e.ElectricEnergyMeter.VerificationDate <= DateTime.Now)?
                    .Select(e => e.ElectricEnergyMeter)
                    .ToList();
                measurers.AddRange(ElectricEnergyMeter);
            }
            return measurers;
        }
    }
}
