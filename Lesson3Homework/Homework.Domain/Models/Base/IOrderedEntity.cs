using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Domain.Models.Base
{
    public interface IOrderedEntity
    {
        int Order { get; set; }
    }
}
