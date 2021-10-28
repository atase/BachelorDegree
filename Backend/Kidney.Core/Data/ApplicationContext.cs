using Kidney.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kidney.Infrastructure.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Giver> Givers { get; set; }
        public DbSet<Receiver> Receivers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Giver>().ToTable("Givers");
            modelBuilder.Entity<Receiver>().ToTable("Receivers");
        }
    }
}
