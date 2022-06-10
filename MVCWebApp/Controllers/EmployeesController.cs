using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MVCWebApp.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: EmployeesController
        public ActionResult Index()
        {
            List<Employee> employees;
            HttpResponseMessage httpResponse = Global.httpClient.GetAsync("Employees").Result;
            employees = httpResponse.Content.ReadAsAsync<List<Employee>>().Result;

            return View(employees);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View(new Employee());
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            HttpResponseMessage httpResponse = Global.httpClient.PostAsJsonAsync("Employees", employee).Result;
            return RedirectToAction("Index");
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            HttpResponseMessage httpResponse = Global.httpClient.GetAsync(String.Format("Employees/{0}",id)).Result;
            return View(httpResponse.Content.ReadAsAsync<Employee>().Result);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            HttpResponseMessage httpResponse = Global.httpClient.PutAsJsonAsync(String.Format("Employees/{0}", employee.EmployeeId),employee).Result;
            return RedirectToAction("Index");
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            HttpResponseMessage httpResponse = Global.httpClient.DeleteAsync(String.Format("Employees/{0}", id)).Result;
            return RedirectToAction("Index");
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
