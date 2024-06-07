﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using SeaGo.Models;

#nullable disable

namespace SeaGo.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240604222755_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SeaGo.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"), 1L, 1);

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("CargoType")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Sector")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("SeaGo.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"), 1L, 1);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("IsCompanyUser")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("PersonId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("SeaGo.Models.PersonAddress", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("PersonId");

                    b.ToTable("PersonAddresses");
                });

            modelBuilder.Entity("SeaGo.Models.PersonCompany", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("PersonId", "CompanyId");

                    b.HasIndex("CompanyId");

                    b.ToTable("PersonCompanies");
                });

            modelBuilder.Entity("SeaGo.Models.ShipDetails", b =>
                {
                    b.Property<int>("ShipDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShipDetailsId"), 1L, 1);

                    b.Property<double>("AirDraft")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<double>("Beam")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<double>("CargoCapacity")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<int>("CompanyId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<double>("Draft")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<double>("LOA")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<DateTime>("LastMaintenanceDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("ShipName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("ShipDetailsId");

                    b.HasIndex("CompanyId");

                    b.ToTable("ShipDetails");
                });

            modelBuilder.Entity("SeaGo.Models.PersonAddress", b =>
                {
                    b.HasOne("SeaGo.Models.Person", "Person")
                        .WithOne("PersonAddress")
                        .HasForeignKey("SeaGo.Models.PersonAddress", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("SeaGo.Models.PersonCompany", b =>
                {
                    b.HasOne("SeaGo.Models.Company", "Company")
                        .WithMany("PersonCompanies")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeaGo.Models.Person", "Person")
                        .WithMany("PersonCompanies")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("SeaGo.Models.ShipDetails", b =>
                {
                    b.HasOne("SeaGo.Models.Company", "Company")
                        .WithMany("ShipDetails")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("SeaGo.Models.Company", b =>
                {
                    b.Navigation("PersonCompanies");

                    b.Navigation("ShipDetails");
                });

            modelBuilder.Entity("SeaGo.Models.Person", b =>
                {
                    b.Navigation("PersonAddress")
                        .IsRequired();

                    b.Navigation("PersonCompanies");
                });
#pragma warning restore 612, 618
        }
    }
}
