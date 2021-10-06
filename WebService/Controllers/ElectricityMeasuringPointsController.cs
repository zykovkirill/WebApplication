using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Models;
using WebShared.Models;

namespace WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ElectricityMeasuringPointsController : ControllerBase
    {
        

        private readonly ILogger<ElectricityMeasuringPointsController> _logger;
        private ApplicationContext _db;
        public ElectricityMeasuringPointsController(ILogger<ElectricityMeasuringPointsController> logger, ApplicationContext context)
        {
            _logger = logger;
            _db = context;
        }


        [HttpGet]
        public async Task <IEnumerable<IVerificatable>> Get()
        {
            return await _db.Measurers.ToListAsync(); 
        }



        [HttpPost]
        public async Task<IActionResult> Post(PointerBuffer pointerBuffer)
        {
            try
            {
                var electricEnergyMeters = await _db.Measurers.FirstOrDefaultAsync(e => e.Id == pointerBuffer.EnergyMeter);
                var transformersCurrent = await _db.Transformers.FirstOrDefaultAsync(t => t.Id == pointerBuffer.Current);
                var transformersVoltage = await _db.Transformers.FirstOrDefaultAsync(t => t.Id == pointerBuffer.Voltage);
                var electricityMeasuringPoints = new ElectricityMeasuringPoint
                {
                    ElectricEnergyMeter = electricEnergyMeters,
                    TransformerCurrent = transformersCurrent,
                    TransformerVoltage = transformersVoltage,
                    Name = pointerBuffer.Name
                };
                await _db.ElectricityMeasuringPoints.AddAsync(electricityMeasuringPoints);
                await _db.SaveChangesAsync();
                return Ok();
            }
           catch
            {
                return BadRequest();
            }
        }
    }
}
