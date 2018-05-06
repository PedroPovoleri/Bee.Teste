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
        public DbSet<User> Roles { get; set; }
        public DbSet<Users> Users { get; set; }


    }
}
