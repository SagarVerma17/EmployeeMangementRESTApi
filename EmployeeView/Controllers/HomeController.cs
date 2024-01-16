using EmployeeRESTApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;  // Add this for List<T>
using System.Net.Http;  // Add this for HttpClient
using Newtonsoft.Json;  // Add this for JsonConvert
using System;

namespace EmployeeView.Controllers
{
    public class HomeController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:8080/api");
        private readonly HttpClient _httpClient;
        public HomeController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<EmployeeViewModel> employeeList = new List<EmployeeViewModel>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Employee").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                employeeList = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(data);
            }

            return View(employeeList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            List<EmployeeViewModel> employeeList = new List<EmployeeViewModel>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Employee").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                employeeList = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(data);
            }

            return View(employeeList);
        }
    }
}