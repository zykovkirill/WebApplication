using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Service
{

    public interface IApi
    {
        public Task<string> GetObjectConsumer();
        public Task<string> PostPointer(string buffer);
        public Task<string> GetMesurer(string id, bool isCurrent, bool isVoltage, bool isMeasurer);
        public Task<string> GetMesurer();
        public Task<string> GetMeteringDevices(string year);
    }

    public class Api: IApi
    {
        private readonly HttpClient _client;
        private const  string _url = "http://localhost:8050/";
        public Api()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetObjectConsumer()
        {
            var response = await _client.GetAsync(_url + "Consumer");
            return  await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetMesurer(string id, bool isCurrent, bool isVoltage, bool isMeasurer)
        {
            var response = await _client.GetAsync(_url + $"Consumer/Measurers?id={id}&isCurrent={isCurrent}&isVoltage={isVoltage}&isMeasurer={isMeasurer}");
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> GetMesurer()
        {
            var response = await _client.GetAsync(_url + $"ElectricityMeasuringPoints");
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> GetMeteringDevices(string year)
        {
            var response = await _client.GetAsync(_url + $"CalculatingMeteringDevice/Year?year={year}");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PostPointer(string buffer)
        {
            string url = _url;

            var content = new StringContent(buffer,
                                Encoding.UTF8,
                                "application/json");

            var response = await _client.PostAsync(url+ "ElectricityMeasuringPoints", content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return "Точка добавлена";
            else
                return "Точка не  добавлена";
        }
    }
}
