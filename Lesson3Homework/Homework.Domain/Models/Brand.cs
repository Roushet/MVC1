using Homework.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Domain.Models
{
    public class Brand : NamedEntity, IOrderedEntity
    {
        public int Order { get ; set ; }
    }
}
