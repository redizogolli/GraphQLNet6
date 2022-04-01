﻿using Microsoft.EntityFrameworkCore;
using QuoteGraphQL.Entities;

namespace QuoteGraphQL.Data
{
    public class QuoteOfTheDayDbContext : DbContext
    {
        public QuoteOfTheDayDbContext(DbContextOptions<QuoteOfTheDayDbContext> options) : base(options)
        {

        }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Quotes)
                .WithOne(q => q.Category)
                .IsRequired();

            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}
