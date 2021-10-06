using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Service;
using WebShared.Models;

namespace WebApplication.Controllers
{

    public class CalculatingMeteringDeviceController :  Controller
    {
        private IApi _apiService;
        public CalculatingMeteringDeviceController(IApi api)
        {
            _apiService = api;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var calculatingMeteringDeviceObject = await _apiService.GetMeteringDevices("2018");
            var calculatingMeteringDevice = JsonConvert.DeserializeObject<IEnumerable<CalculatingMeteringDevice>>(calculatingMeteringDeviceObject);
            return View(calculatingMeteringDevice);

        }
    }
}
