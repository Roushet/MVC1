using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Domain.Models.Base
{
    //интерфейс публичный. иначе не будет видно
    public interface IBaseEntity
    {
        int Id { get; set; }
    }
}
