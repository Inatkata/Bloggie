﻿using Bloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Data
{
    public class BloggieDbContext : DbContext
    {
        public BloggieDbContext(DbContextOptions<BloggieDbContext> options)
            : base(options)
        {
        }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>()
                .HasMany(bp => bp.Tags)
                .WithMany(t => t.BlogPosts);
            base.OnModelCreating(modelBuilder);
        }*/
    }
}
