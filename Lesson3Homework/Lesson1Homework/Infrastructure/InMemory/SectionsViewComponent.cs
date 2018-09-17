using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework.Domain.Models;
using Lesson1Homework.Infrastructure.Interfaces;

namespace Lesson1Homework.Models
{
    public class SectionsViewComponent : ViewComponent
    {
        private readonly IProductData _productData;

        public SectionsViewComponent(IProductData productData)
        {
            _productData = productData;
        }

        //TODO разобраться как сделать метод асинхронным
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sections = GetSections();
            
            return View(sections);
        }
        private List<SectionView> GetSections()
        {
            var categories = _productData.GetSections();
            var parentCategories = categories.Where(p => !p.ParentId.HasValue).ToArray();
            var parentSections = new List<SectionView>();
            foreach (var parentCategory in parentCategories)
            {
                parentSections.Add(new SectionView()
                {
                    Id = parentCategory.Id,
                    Name = parentCategory.Name,
                    Order = parentCategory.Order,
                    ParentSection = null
                });
            }
            foreach (var sectionViewModel in parentSections)
            {
                var childCategories = categories.Where(c => c.ParentId.Equals(sectionViewModel.Id));
                foreach (var childCategory in childCategories)
                {
                    sectionViewModel.ChildSections.Add(new SectionView()
                    {
                        Id = childCategory.Id,
                        Name = childCategory.Name,
                        Order = childCategory.Order,
                        ParentSection = sectionViewModel
                    });
                }
                sectionViewModel.ChildSections = sectionViewModel.ChildSections.OrderBy(c =>
                c.Order).ToList();
            }
            parentSections = parentSections.OrderBy(c => c.Order).ToList();
            return parentSections;
        }
    }

}
}
