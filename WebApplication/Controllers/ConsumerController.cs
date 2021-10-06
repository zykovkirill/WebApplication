using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Service;
using WebApplication.Models;
namespace WebApplication.Controllers
{
    public class ConsumerController : Controller
    {
        private IApi _apiService;
        public ConsumerController(IApi api)
        {
            _apiService = api;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var objectConsumer = await _apiService.GetObjectConsumer();
            var consumer = JsonConvert.DeserializeObject<List<Сonsumer>>(objectConsumer);
            return View(consumer);

        }

        [HttpPost]
        public async Task  <IActionResult> Index(string objectConsumer, bool type1, bool type2, bool type3)
        {
            var objectMesurer = await _apiService.GetMesurer(objectConsumer, type1, type2,type3);
            var measurer = JsonConvert.DeserializeObject<List<Measurer>>(objectMesurer);
            return View("Measurer",measurer);
        }
    }
}
