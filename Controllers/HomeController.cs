using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmployeeTracking.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTracking.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            ViewBag.AllDepartments = _context.Departments.ToList();
            ViewBag.AllEmployees = _context.Employees.Include(d => d.Department).ToList();
            return View();
        }

        [HttpPost("addDepartment")]
        public IActionResult addDepartment(Department newDepartment)
        {
            if(ModelState.IsValid)
            {
                _context.Add(newDepartment);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            } else {

                ViewBag.AllDepartments = _context.Departments.ToList();
                ViewBag.AllEmployees = _context.Employees.Include(d => d.Department).ToList();
                return View("Dashboard");
            }
        }

        [HttpPost("addEmployee")]
        public IActionResult addEmployee(Employee newEmployee)
        {
            if(ModelState.IsValid)
            {
                _context.Add(newEmployee);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            } else {

                ViewBag.AllDepartments = _context.Departments.ToList();
                ViewBag.AllEmployees = _context.Employees.Include(d => d.Department).ToList();
                return View("Dashboard");
            }
        }

        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            ViewBag.AllDepartments = _context.Departments.ToList();
            ViewBag.AllEmployees = _context.Employees.Include(d => d.Department).ToList();
            return View();
        }
    }
}
