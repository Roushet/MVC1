using Homework.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson1Homework.Models
{
    public class SectionView : INamedEntity, IOrderedEntity
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Order { get; set; }

        public List<SectionView> ChildSections { get; set; }
        public SectionView ParentSection { get; set; }

        public SectionView()
        {
            ChildSections = new List<SectionView>();
        }
    }
}
