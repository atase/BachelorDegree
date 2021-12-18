using Kidney.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityMaps
{
    public static class PrimaryDiagnosisMap
    {
        public static ModelBuilder Map(ModelBuilder modelBuilder)
        {
            return modelBuilder.Entity<PrimaryDiagnosis>(entity =>
            {
                entity.ToTable("PRIMARY_DIAGNOSIS");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id).HasColumnName("ID");
                entity.Property(x => x.Name).HasColumnName("NAME");

                entity.HasMany(x => x.Receivers)
                      .WithOne(x => x.PrimaryDiagnosis)
                      .HasForeignKey(x => x.PrimaryDiagnosisId);
            });
        }
    }
}
