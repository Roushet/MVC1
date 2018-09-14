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

        [Route("{id}")]
        public IActionResult Details(int id)
        {
            var emp = _employees.GetById(id);
            if (ReferenceEquals(emp, null))
                return NotFound();

            return View(emp);

        }

        [Route("edit/{id}")]
        public IActionResult Edit(int? id)
        {
            EmployeeView employeeView;
            //мощно использую синтаксический сахар ??
            employeeView = _employees.GetById(id.Value) ?? new EmployeeView();

            return View(employeeView);
        }


        //перегрузка экшена эдит?
        [Route("edit/{id}")]
        public IActionResult Edit(EmployeeView employeeView)
        {
            if (employeeView.Id > 0)
            {
                EmployeeView dbItem = _employees.GetById(employeeView.Id);

                if (ReferenceEquals(dbItem, null))
                    return NotFound();

                dbItem.FirstName = employeeView.FirstName;
                dbItem.Patronymic = employeeView.Patronymic;
                dbItem.Surname = employeeView.Surname;
                dbItem.Age = employeeView.Age;
            }
            else
                //TODO разобраться чё мы тут добавляем, employeeView или dbItem
                _employees.AddNew(employeeView);
            return RedirectToAction(nameof(Index));
        }

    }
}