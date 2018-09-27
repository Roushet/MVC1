using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;

namespace Lesson1Homework.Models.Account
{
    //Наколхозил модель, которой не было в методичке
    public class LoginViewModel : RegisterUserViewModel
    {
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; internal set; }
    }
}
