
using DataAccess.Entities;
using DataAccess.EntityMaps;
using Kidney.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kidney.DataAccess.DataContexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Receiver> Receivers { get; set; }
        public DbSet<Giver> Givers { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<PrimaryDiagnosis> PrimaryDiagnoses { get; set; }
        public DbSet<ContactInformations> ContactInformations { get; set; }
        public DbSet<CompatibilityScore> CompatibilityScores { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            ReceiverMap.Map(modelBuilder);
            GiverMap.Map(modelBuilder);
            PrimaryDiagnosisMap.Map(modelBuilder);
            RaceMap.Map(modelBuilder);
            ContactInformationsMap.Map(modelBuilder);
            CompatibilityScoreMap.Map(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
