using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Domain.Models.Base
{
    public interface INamedEntity : IBaseEntity
    {
        string Name { get; set; }
    }
}
