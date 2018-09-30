using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework.Domain.Models;
using Homework.DAL;
using Microsoft.EntityFrameworkCore;
using Lesson1Homework.Infrastructure.InMemory;

namespace Lesson1Homework.Data
{
    public static class DbInitializer
    {

        public static void Initialize(HomeworkContext context)
        {
            context.Database.EnsureCreated();
            // Look for any products.
            if (context.Products.Any())
            {
                return; // DB has been seeded
            }
            var sections = new List<Section>();
            sections = (new InMemoryProductData()).GetSections().ToList<Section>();

            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var section in sections)
                {
                    context.Sections.Add(section);
                }
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Sections] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Sections] OFF");
                trans.Commit();
            }
            var brands = new List<Brand>();
            brands = (new InMemoryProductData()).GetBrands().ToList<Brand>();

            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var brand in brands)
                {
                    context.Brands.Add(brand);
                }
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Brands] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Brands] OFF");
                trans.Commit();
            }
            var products = new List<Product>();
            products = (new InMemoryProductData()).GetProducts().ToList<Product>();

            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var product in products)
                {
                    context.Products.Add(product);
                }
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Products] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Products] OFF");
                trans.Commit();
            }

        }
    }
}
