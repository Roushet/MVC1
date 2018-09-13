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


        public IActionResult Index()
        {
            //return Content("Controller");
            return View();
        }

        //public IActionResult Details (int id)
        //{

        //    return View();
        //}
    }
}