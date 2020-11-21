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
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PostCategories> PostCategories { get; set; }
        public DbSet<PostTags> PostTags { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
            .HasMany(c => c.Comments)
            .WithOne(p => p.Post)
            .IsRequired();

            modelBuilder.Entity<PostCategories>()
            .HasKey(bc => new { bc.PostId, bc.CategoryId });

            modelBuilder.Entity<PostCategories>()
            .HasOne(bc => bc.Post)
            .WithMany(b => b.PostCategories)
            .HasForeignKey(bc => bc.PostId);

            modelBuilder.Entity<PostCategories>()
            .HasOne(bc => bc.Category)
            .WithMany(c => c.PostCategories)
            .HasForeignKey(bc => bc.CategoryId);

            modelBuilder.Entity<PostTags>()
            .HasKey(bc => new { bc.PostId, bc.TagId });

            modelBuilder.Entity<PostTags>()
            .HasOne(bc => bc.Post)
            .WithMany(b => b.PostTags)
            .HasForeignKey(bc => bc.PostId);

            modelBuilder.Entity<PostTags>()
            .HasOne(bc => bc.Tag)
            .WithMany(c => c.PostTags)
            .HasForeignKey(bc => bc.TagId);

            //modelBuilder.Entity<Comment>()
            //.Property(p => p.CommentId).ValueGeneratedOnAdd();


        }
    }
}
