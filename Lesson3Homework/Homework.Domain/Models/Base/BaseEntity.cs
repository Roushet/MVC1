using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Domain.Models.Base
{
    class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
    }
}
