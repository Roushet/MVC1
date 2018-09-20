using Homework.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Homework.Domain.Models
{
    [Table("Sections")]
    public class Section: NamedEntity, IOrderedEntity
    {
        [ForeignKey("ParentId")]
        public int? ParentId { get; set; }

        public int Order { get; set; }
    }
}
