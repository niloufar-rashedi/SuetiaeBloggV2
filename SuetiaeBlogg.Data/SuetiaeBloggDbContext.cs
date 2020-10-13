using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SuetiaeBlogg.Core.Models;

namespace SuetiaeBlogg.Data
{
    public class SuetiaeBloggDbContext : DbContext
    {
        public SuetiaeBloggDbContext(DbContextOptions<SuetiaeBloggDbContext> options) : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Author> Authors { get; set; }
    }
    
}
