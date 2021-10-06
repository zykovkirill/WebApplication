using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Service;

namespace WebApplication.Controllers
{

    public class ElectricityMeasuringPointController : Controller
    {
        private IApi _apiService;
        public ElectricityMeasuringPointController(IApi api)
        {
            _apiService = api;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var objectMesurer = await _apiService.GetMesurer();
            var measurers = JsonConvert.DeserializeObject<List<Measurer>>(objectMesurer);
            return View(measurers);

        }

        [HttpPost]
        public async Task<IActionResult> Index(string name, string voltage, string current, string energyMeter)
        {
            var pointerBuffer = new PointerBuffer()
            {
                Name = name,
                Current = current,
                Voltage = voltage,
                EnergyMeter = energyMeter
            };
            var pointerBufferString = JsonConvert.SerializeObject(pointerBuffer);
            var message = await _apiService.PostPointer(pointerBufferString);
            return View("Message",message);
        }
    }
}
