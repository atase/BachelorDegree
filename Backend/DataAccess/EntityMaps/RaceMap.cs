using Kidney.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityMaps
{
    public static class RaceMap
    {
        public static ModelBuilder Map(ModelBuilder modelBuilder)
        {
            return modelBuilder.Entity<Race>(entity => {
                entity.ToTable("RACE");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id).HasColumnName("ID");
                entity.Property(x => x.Type).HasColumnName("TYPE");
            });
        }
   
    }
}
