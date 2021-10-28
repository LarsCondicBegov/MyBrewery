using Microsoft.EntityFrameworkCore;
using MyBrewery.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBrewery.Infrastructure.Context
{
    public class MyBreweryDbContext : DbContext
    {
        public MyBreweryDbContext(DbContextOptions<MyBreweryDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Recipe>()
                .ToTable("Recipe");
        }
    }
}
