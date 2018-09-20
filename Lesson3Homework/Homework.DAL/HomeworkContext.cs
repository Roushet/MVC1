using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Homework.Domain.Models;

namespace Homework.DAL
{
    public class HomeworkContext : DbContext
    {
        public HomeworkContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Brand> Brands { get; set; }

    }
}
