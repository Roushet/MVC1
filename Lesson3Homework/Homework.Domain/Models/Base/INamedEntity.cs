using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Domain.Models.Base
{
    interface INamedEntity : IBaseEntity
    {
        string Name { get; set; }
    }
}
