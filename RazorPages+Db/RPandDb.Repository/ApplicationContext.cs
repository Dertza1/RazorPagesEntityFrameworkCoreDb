using System.Collections.Generic;
using System;
using RPandDb.Model;
using Microsoft.EntityFrameworkCore;

namespace RPandDb.Db
{
    public class ApplicationContext:DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User { Id = 1, Name = "Tom" },
                    new User { Id = 2, Name = "Bob" },
                    new User { Id = 3, Name = "Sam" }
            );
        }
    }
}
