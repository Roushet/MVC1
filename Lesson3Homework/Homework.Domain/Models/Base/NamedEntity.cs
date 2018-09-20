using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Domain.Models.Base
{
    public class NamedEntity : INamedEntity
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
