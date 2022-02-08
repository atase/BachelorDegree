﻿// <auto-generated />
using System;
using Kidney.DataAccess.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220117210017_Migration71")]
    partial class Migration71
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccess.Entities.ContactInformations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContactInformations");
                });

            modelBuilder.Entity("Kidney.DataAccess.Entities.Giver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasColumnName("AGE");

                    b.Property<int>("BloodType")
                        .HasColumnType("int")
                        .HasColumnName("BLOOD_TYPE");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CITY");

                    b.Property<int?>("ContactInformationsId")
                        .HasColumnType("int")
                        .HasColumnName("CONTACT_INFORMATIONS_ID");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("COUNTRY");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FIRST_NAME");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LAST_NAME");

                    b.Property<int?>("RaceId")
                        .HasColumnType("int")
                        .HasColumnName("RACE_ID");

                    b.Property<int>("Sex")
                        .HasColumnType("int")
                        .HasColumnName("SEX");

                    b.HasKey("Id");

                    b.HasIndex("ContactInformationsId");

                    b.HasIndex("RaceId");

                    b.ToTable("GIVER");
                });

            modelBuilder.Entity("Kidney.DataAccess.Entities.PrimaryDiagnosis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("PRIMARY_DIAGNOSIS");
                });

            modelBuilder.Entity("Kidney.DataAccess.Entities.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TYPE");

                    b.HasKey("Id");

                    b.ToTable("RACE");
                });

            modelBuilder.Entity("Kidney.DataAccess.Entities.Receiver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasColumnName("AGE");

                    b.Property<int>("BloodType")
                        .HasColumnType("int")
                        .HasColumnName("BLOOD_TYPE");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CITY");

                    b.Property<int?>("ContactInformationsId")
                        .HasColumnType("int")
                        .HasColumnName("CONTACT_INFORMATIONS_ID");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("COUNTRY");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FIRST_NAME");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LAST_NAME");

                    b.Property<int?>("PrimaryDiagnosisId")
                        .HasColumnType("int")
                        .HasColumnName("PRIMARY_DIAGNOSIS_ID");

                    b.Property<int?>("RaceId")
                        .HasColumnType("int")
                        .HasColumnName("RACE_ID");

                    b.Property<int>("Sex")
                        .HasColumnType("int")
                        .HasColumnName("SEX");

                    b.HasKey("Id");

                    b.HasIndex("ContactInformationsId");

                    b.HasIndex("PrimaryDiagnosisId");

                    b.HasIndex("RaceId");

                    b.ToTable("RECEIVER");
                });

            modelBuilder.Entity("Kidney.DataAccess.Entities.Giver", b =>
                {
                    b.HasOne("DataAccess.Entities.ContactInformations", "ContactInformations")
                        .WithMany()
                        .HasForeignKey("ContactInformationsId");

                    b.HasOne("Kidney.DataAccess.Entities.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId");

                    b.Navigation("ContactInformations");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("Kidney.DataAccess.Entities.Receiver", b =>
                {
                    b.HasOne("DataAccess.Entities.ContactInformations", "ContactInformations")
                        .WithMany()
                        .HasForeignKey("ContactInformationsId");

                    b.HasOne("Kidney.DataAccess.Entities.PrimaryDiagnosis", "PrimaryDiagnosis")
                        .WithMany()
                        .HasForeignKey("PrimaryDiagnosisId");

                    b.HasOne("Kidney.DataAccess.Entities.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId");

                    b.Navigation("ContactInformations");

                    b.Navigation("PrimaryDiagnosis");

                    b.Navigation("Race");
                });
#pragma warning restore 612, 618
        }
    }
}
