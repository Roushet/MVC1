using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Homework.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Homework.DAL
{
    public class HomeworkContext : IdentityDbContext<User>
    {
        public HomeworkContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Brand> Brands { get; set; }

    }
}
