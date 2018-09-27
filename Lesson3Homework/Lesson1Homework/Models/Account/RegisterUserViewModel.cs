using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lesson1Homework.Models.Account
{
    public class RegisterUserViewModel
    {
        [Required, MaxLength(64)]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password), MaxLength(64)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword{ get; set; }
    }
}
