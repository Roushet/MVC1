using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework.Domain.Models;
using Lesson1Homework.Infrastructure.Interfaces;
using Lesson1Homework.Models;

namespace Lesson1Homework.Infrastructure.InMemory
{
    public class InMemoryProductData : IProductData
    {
        private readonly List<Section> _sections;
        private readonly List<Brand> _brands;

        public InMemoryProductData()
        {
            _sections = new List<Section>()
            {
                new Section()
                {
                    Id = 1,
                    Name = "Sportswear",
                    Order = 0,
                    ParentId = null
                },

new Section()
                {
                    Id = 2,
                    Name = "Mike",
                    Order = 1,
                    ParentId = null
                },

new Section()
                {
                    Id = 3,
                    Name = "Abibas",
                    Order = 3,
                    ParentId = null
                },

new Section()
                {
                    Id = 4,
                    Name = "Mens",
                    Order = 4,
                    ParentId = null
                },
new Section()
                {
                    Id = 5,
                    Name = "Ecco",
                    Order = 0,
                    ParentId = 4
                }

            };

            _brands = new List<Brand>()
            {
                new Brand()
                {
                    Id= 1,
                    Name = "Weebok",
                    Order = 0,
                },
                new Brand()
                {
                    Id= 2,
                    Name = "Poma",
                    Order = 1,
                }

            };
        }

        public IEnumerable<Brand> GetBrands()
        {
            return _brands;
        }

        public IEnumerable<Section> GetSections()
        {
            return _sections;
        }
    }
}
