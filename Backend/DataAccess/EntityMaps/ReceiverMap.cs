using Kidney.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityMaps
{
    class ReceiverMap
    {
        public static ModelBuilder Map(ModelBuilder modelBuilder)
        {
            return modelBuilder.Entity<Receiver>(entity => {
                entity.ToTable("RECEIVER");

                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).HasColumnName("ID");
                entity.Property(x => x.FirstName).HasColumnName("FIRST_NAME");
                entity.Property(x => x.LastName).HasColumnName("LAST_NAME");
                entity.Property(x => x.Country).HasColumnName("COUNTRY");
                entity.Property(x => x.City).HasColumnName("CITY");
                entity.Property(x => x.Age).HasColumnName("AGE");
                entity.Property(x => x.Email).HasColumnName("EMAIL");
                entity.Property(x => x.PhoneNumber).HasColumnName("PHONE_NUMBER");
                entity.Property(x => x.RaceId).HasColumnName("RACE_ID");
                entity.Property(x => x.Sex).HasColumnName("SEX");
                entity.Property(x => x.BloodType).HasColumnName("BLOOD_TYPE");
                entity.Property(x => x.PrimaryDiagnosisId).HasColumnName("PRIMARY_DIAGNOSIS_ID");

                entity.HasOne(x => x.Race)
                    .WithMany(y => y.Receivers)
                    .HasForeignKey(y => y.RaceId);

                entity.HasOne(x => x.PrimaryDiagnosis)
                   .WithMany(y => y.Receivers)
                   .HasForeignKey(y => y.PrimaryDiagnosisId);

            });
        }
    }
}
