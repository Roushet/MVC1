using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson1Homework.Models;

namespace Lesson1Homework.Infrastructure.Interfaces
{
    public interface IEmployeesData
    {
        IEnumerable<EmployeeView> GetAll();

        EmployeeView GetById(int id);

        void AddNew(EmployeeView employee);

        void Delete(int id);
    }
}
