using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Service;

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
            var calculatingMeteringDeviceObject = await _apiService.GetMeteringDevices("2021");
            var calculatingMeteringDevice = JsonConvert.DeserializeObject<IEnumerable<CalculatingMeteringDevice>>(calculatingMeteringDeviceObject);
            return View(calculatingMeteringDevice);

        }

        //[HttpPost]
        //public async Task<IActionResult> Index(string objectConsumer, bool type1, bool type2, bool type3)
        //{
        //    var objectMesurer = await _apiService.GetMesurer(objectConsumer, type1, type2, type3);
        //    var measurer = JsonConvert.DeserializeObject<List<Measurer>>(objectMesurer);
        //    return View("Measurer", measurer);
        //}
    }
}
