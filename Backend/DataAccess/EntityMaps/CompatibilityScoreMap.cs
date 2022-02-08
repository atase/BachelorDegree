using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityMaps
{
    public class CompatibilityScoreMap
    {
        public static ModelBuilder Map(ModelBuilder modelBuilder)
        {
            return modelBuilder.Entity<CompatibilityScore>(entity =>
            {

                entity.ToTable("COMPATIBILITIES_SCORES");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.GiverId).HasColumnName("GIVER_ID");
                entity.Property(e => e.ReceiverId).HasColumnName("RECEIVER_ID");
                entity.Property(e => e.Score).HasColumnName("SCORE");

                entity.HasOne(e => e.Giver)
                      .WithMany()
                      .HasForeignKey(e => e.GiverId);

                entity.HasOne(e => e.Receiver)
                      .WithMany()
                      .HasForeignKey(e => e.ReceiverId);

            });
        }
    }
}
