using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson1Homework.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson1Homework.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<EmployeeView> list = new List<EmployeeView>
        {
            new EmployeeView
            {
                Id = 1,
                FirstName = "Имя 1",
                Patronymic = "Отчество 1",
                Surname = "Фамилия 1",
                Age = 11
            },

          new EmployeeView
            {
                Id = 2,
                FirstName = "Имя 2",
                Patronymic = "Отчество 2",
                Surname = "Фамилия 2",
                Age = 22
            },

          new EmployeeView
            {
                Id = 3,
                FirstName = "Имя 3",
                Patronymic = "Отчество 3",
                Surname = "Фамилия 3",
                Age = 33
            },

            new EmployeeView
            {
                Id = 1,
                FirstName = "Имя 4",
                Patronymic = "Отчество 4",
                Surname = "Фамилия 4",
                Age = 44
            },

        };

        public IActionResult Index()
        {
            //return Content("Controller");
            return View(list);
        }

        public IActionResult Details (int id)
        {

            return View(list[id]);
        }
    }
}