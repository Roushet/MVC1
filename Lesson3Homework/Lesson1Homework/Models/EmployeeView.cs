using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson1Homework.Models
{
    public class EmployeeView
    {
        //ИД никто не видит
        public int Id { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage ="Имя обязательно")]
        [Display(Name ="Имя")]
        [StringLength(maximumLength:50, MinimumLength =2, ErrorMessage ="Длина имени от 2 до 50 символов")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Фамилия обязательна")]
        [Display(Name = "Фамилия")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Длина фамилии от 2 до 50 символов")]
        public string Surname { get; set; }

        //отчество оставляем необязательным
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Возраст обязателен")]
        [Display(Name = "Возраст")]
        [Range(10, 100, ErrorMessage ="Возраст не может быть меньше 10 и больше 100 лет")]
        public int Age { get; set; }
    }
}
