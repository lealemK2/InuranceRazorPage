﻿// <auto-generated />
using System;
using InuranceRazorPage.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InuranceRazorPage.Migrations
{
    [DbContext(typeof(InuranceRazorPageContext))]
    [Migration("20230201104135_deleteLocationColFromAccounts")]
    partial class deleteLocationColFromAccounts
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("InuranceRazorPage.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddressId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Createdon")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Fathername")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("InuranceRazorPage.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("HouseNumber")
                        .HasColumnType("integer");

                    b.Property<int>("SubcityId")
                        .HasColumnType("integer");

                    b.Property<int?>("Woreda")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubcityId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("InuranceRazorPage.Models.Cbhi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AdditionalMembers")
                        .HasColumnType("integer");

                    b.Property<string>("BaseCbhi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("boolean");

                    b.Property<int>("NthTracker")
                        .HasColumnType("integer");

                    b.Property<int>("PackageId")
                        .HasColumnType("integer");

                    b.Property<int>("PayableMembers")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("TotalMembers")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PackageId");

                    b.ToTable("Cbhis");
                });

            modelBuilder.Entity("InuranceRazorPage.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("integer");

                    b.Property<int>("CbhiId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Createdon")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Fathername")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("boolean");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LoginCbhi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Relation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CbhiId");

                    b.HasIndex("LoginCbhi")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("InuranceRazorPage.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("SubcityId")
                        .HasColumnType("integer");

                    b.Property<int>("woreda")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubcityId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("InuranceRazorPage.Models.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AdditionalFeePerAdult")
                        .HasColumnType("numeric");

                    b.Property<bool>("CanAddMember")
                        .HasColumnType("boolean");

                    b.Property<int>("MaxNumberOfAdult")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("InuranceRazorPage.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AdditionalFeePerMember")
                        .HasColumnType("numeric");

                    b.Property<int>("AdditionalMembers")
                        .HasColumnType("integer");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("CbhiId")
                        .HasColumnType("integer");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("LimitOfMembersPerPackage")
                        .HasColumnType("integer");

                    b.Property<decimal>("PackageFee")
                        .HasColumnType("numeric");

                    b.Property<string>("PackageName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PayableMembers")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CbhiId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("InuranceRazorPage.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleName")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("InuranceRazorPage.Models.Subcity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Subcities");
                });

            modelBuilder.Entity("InuranceRazorPage.Models.Account", b =>
                {
                    b.HasOne("InuranceRazorPage.Models.Address", "Address")
                        .WithOne("Account")
                        .HasForeignKey("InuranceRazorPage.Models.Account", "AddressId");

                    b.HasOne("InuranceRazorPage.Models.Role", "role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("role");
                });

            modelBuilder.Entity("InuranceRazorPage.Models.Address", b =>
                {
                    b.HasOne("InuranceRazorPage.Models.Subcity", "Subcity")
                        .WithMany()
                        .HasForeignKey("SubcityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subcity");
                });

            modelBuilder.Entity("InuranceRazorPage.Models.Cbhi", b =>
                {
                    b.HasOne("InuranceRazorPage.Models.Package", "Package")
                        .WithMany()
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Package");
                });

            modelBuilder.Entity("InuranceRazorPage.Models.Customer", b =>
                {
                    b.HasOne("InuranceRazorPage.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InuranceRazorPage.Models.Cbhi", "Cbhi")
                        .WithMany()
                        .HasForeignKey("CbhiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Cbhi");
                });

            modelBuilder.Entity("InuranceRazorPage.Models.Location", b =>
                {
                    b.HasOne("InuranceRazorPage.Models.Subcity", "Subcity")
                        .WithMany()
                        .HasForeignKey("SubcityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subcity");
                });

            modelBuilder.Entity("InuranceRazorPage.Models.Payment", b =>
                {
                    b.HasOne("InuranceRazorPage.Models.Cbhi", "Cbhi")
                        .WithMany()
                        .HasForeignKey("CbhiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InuranceRazorPage.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cbhi");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("InuranceRazorPage.Models.Address", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
