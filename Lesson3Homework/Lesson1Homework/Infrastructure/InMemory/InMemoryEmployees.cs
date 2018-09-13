using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson1Homework.Infrastructure.Interfaces;
using Lesson1Homework.Models;

namespace Lesson1Homework.Infrastructure
{
    public class InMemoryEmployees : IEmployeesData
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



        void IEmployeesData.AddNew(EmployeeView employee)
        {
            employee.Id = list.Max(e => e.Id) + 1;
            list.Add(employee);
        }

        void IEmployeesData.Delete(int id)
        {
            EmployeeView employee = list.FirstOrDefault<EmployeeView>(e => e.Id.Equals(id));
            if (employee != null)
                list.Remove(employee);

        }


        IEnumerable<EmployeeView> IEmployeesData.GetAll()
        {
            return list;
        }

        EmployeeView IEmployeesData.GetById(int id)
        {
            return list.FirstOrDefault<EmployeeView>(e => e.Id.Equals(id));
        }
    }
}
