using Homework.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Domain.Models
{
    public class Section: NamedEntity, IOrderedEntity
    {
        public int? ParentId { get; set; }

        public int Order { get; set; }
    }
}
