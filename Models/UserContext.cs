using Microsoft.EntityFrameworkCore;
using System;

namespace entityframework.Models
{
    public class UserContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            User user = new User();
            user.id = Guid.NewGuid();
            user.name = "Angel";
            user.email = "angel@gmail.com";
            user.password = "123";
            modelBuilder.Entity<User>().HasData(user);
        }

    }
}