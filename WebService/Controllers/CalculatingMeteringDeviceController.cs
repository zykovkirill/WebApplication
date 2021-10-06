using Microsoft.AspNetCore.Mvc;
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
    public class CalculatingMeteringDeviceController : ControllerBase
    {
        

        private readonly ILogger<CalculatingMeteringDeviceController> _logger;
        private ApplicationContext _db;
        public CalculatingMeteringDeviceController(ILogger<CalculatingMeteringDeviceController> logger, ApplicationContext context)
        {
            _logger = logger;
            _db = context;
        }

        [HttpGet("Year")]
        public IEnumerable<CalculatingMeteringDevice> Get(string year)
        {
            return  _db.CalculatingMeteringDevices.Where(c => c.CreatedDate.Year.ToString() == year);
        }
    }
}
