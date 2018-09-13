using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lesson1Homework.Models;
using Lesson1Homework.Infrastructure.Interfaces;

namespace Lesson1Homework.Controllers
{
    [Route("users")]
    public class EmployeeController : Controller
    {
        private IEmployeesData _employees;

        public EmployeeController(IEmployeesData employees)
        {
            _employees = employees;
        }

        public IActionResult Index()
        {
            return View(_employees.GetAll());
        }

        [Route("details")]
        public IActionResult Details(int id)
        {
            var emp = _employees.GetById(id);
            if (emp != null)
                return View(emp);
            else
                return NotFound();

        }
    }
}