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
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostCategory> PostsCategories { get; set; }
        //public DbSet<Comment> Comments { get; set; }

        //public DbSet<Author> Authors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostCategory>()
         .HasKey(bc => new { bc.PostId, bc.CategoryId });
            modelBuilder.Entity<PostCategory>()
                .HasOne(bc => bc.Post)
                .WithMany(b => b.PostsCategories)
                .HasForeignKey(bc => bc.PostId);
            modelBuilder.Entity<PostCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.PostsCategories)
                .HasForeignKey(bc => bc.CategoryId);



        }

    

    }
    
}
