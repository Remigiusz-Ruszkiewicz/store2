using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using store2.Models;

namespace store2.Data
{
    public class DataContext : IdentityDbContext
    {
        public DbSet<Product> Products{ get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
    }
}
