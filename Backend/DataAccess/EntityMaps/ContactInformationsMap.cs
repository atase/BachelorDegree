using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityMaps
{
    public class ContactInformationsMap
    {
        public static ModelBuilder Map(ModelBuilder modelBuilder) 
        {
            return modelBuilder.Entity<ContactInformations>(entity =>
            {
                entity.ToTable("CONTACT_INFORMATIONS");

                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).HasColumnName("ID");
                entity.Property(x => x.Email).HasColumnName("EMAIL");
                entity.Property(x => x.PhoneNumber).HasColumnName("PHONE_NUMBER");
                
            });
        }
    }
}
