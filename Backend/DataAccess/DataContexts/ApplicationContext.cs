
using DataAccess.EntityMaps;
using Kidney.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

namespace Kidney.DataAccess.DataContexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Receiver> Receivers { get; set; }
        public DbSet<Giver> Givers { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<PrimaryDiagnosis> PrimaryDiagnoses { get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            ReceiverMap.Map(modelBuilder);
            GiverMap.Map(modelBuilder);
            PrimaryDiagnosisMap.Map(modelBuilder);
            RaceMap.Map(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
