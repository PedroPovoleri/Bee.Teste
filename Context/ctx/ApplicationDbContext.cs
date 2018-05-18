using Microsoft.EntityFrameworkCore;
using Model.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Context.ctx
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Customers> Customers { get; set; }
        
        public DbSet<Roles> Roles { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<UserRoles> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Define composite key.
            builder.Entity<UserRoles>()
                .HasKey(lc => new { lc.UserId, lc.RoleId});
        }

    }
}
