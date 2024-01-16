using EmployeeRESTApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;  // Add this for List<T>
using System.Net.Http;  // Add this for HttpClient
using Newtonsoft.Json;  // Add this for JsonConvert
using System;
using System.Text;

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

        [HttpDelete("{id}")]
        public IActionResult DeleteView(int? id)
        {
            try
            {
                HttpResponseMessage response = _httpClient.DeleteAsync(_httpClient.BaseAddress + "/Employee/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteABC(int? id)
        {

            if (id > 0)
            {
                try
                {
                    HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Employee/" + id).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        DeleteView(id);
                        Index();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Error deleting employee: {ex.Message}");
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public EmployeeViewModel getEmployeebyId(int? id)
        {
            EmployeeViewModel employeeList = new EmployeeViewModel();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Employee/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                employeeList = JsonConvert.DeserializeObject<EmployeeViewModel>(data);
            }

            return employeeList;
        }


        [HttpGet]
        public IActionResult CreateView(int? id)
        {
            EmployeeViewModel employee = new EmployeeViewModel();
            if (id > 0)
            {
                employee = getEmployeebyId(id);
            }
            return View(employee);
        }

        //[HttpPut({"id"})]
        //public IActionResult Edit(int id)
        //{

        //    return View();
        //}



        [HttpPost]
        public IActionResult CreateOrEdit(EmployeeViewModel employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest("Employee object is null");
                }
                else if (employee.EmpId == 0)
                {
                    string jsonEmployee = JsonConvert.SerializeObject(employee);
                    StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "/Employee", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        string errorMessage = $"Error Creating Employee: {response.StatusCode} - {response.ReasonPhrase}";
                        ModelState.AddModelError(string.Empty, errorMessage);
                        return View(employee);
                    }
                }
                else if (employee.EmpId > 0)
                {
                    try
                    {
                        editData(employee);
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error creating employee: {ex.Message}");
                return View(employee);
            }

            return View();
        }

        [HttpPut("{id}")]
        public IActionResult editData(EmployeeViewModel employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest("Employee object is null");
                }
                else if (employee.EmpId > 0)
                {
                    string jsonEmployee = JsonConvert.SerializeObject(employee);
                    StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = _httpClient.PutAsync(_httpClient.BaseAddress + "/Employee/" + employee.EmpId, content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        string errorMessage = $"Error Creating Employee: {response.StatusCode} - {response.ReasonPhrase}";
                        ModelState.AddModelError(string.Empty, errorMessage);
                        return View(employee);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error creating employee: {ex.Message}");
                return View(employee);
            }
            return RedirectToAction("Index");
        }



    }
}