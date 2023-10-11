﻿// <auto-generated />
using System;
using API.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(ZooManagementBackupContext))]
    partial class ZooManagementBackupContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Models.Entities.Animal", b =>
                {
                    b.Property<string>("AnimalId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Behavior")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte?>("HealthStatus")
                        .HasColumnType("tinyint");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ImportDate")
                        .HasColumnType("datetime2");

                    b.Property<byte?>("IsDeleted")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rarity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpeciesId")
                        .HasColumnType("int");

                    b.HasKey("AnimalId");

                    b.HasIndex("CageId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("SpeciesId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("API.Models.Entities.AnimalSpecies", b =>
                {
                    b.Property<int>("SpeciesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpeciesId"));

                    b.Property<string>("SpeciesName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpeciesId");

                    b.ToTable("AnimalSpecies");
                });

            modelBuilder.Entity("API.Models.Entities.Area", b =>
                {
                    b.Property<string>("AreaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AreaName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AreaId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("API.Models.Entities.Cage", b =>
                {
                    b.Property<string>("CageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AreaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CageId");

                    b.HasIndex("AreaId");

                    b.ToTable("Cages");
                });

            modelBuilder.Entity("API.Models.Entities.Certificate", b =>
                {
                    b.Property<string>("CertificateCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CertificateName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Level")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrainingInstitution")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CertificateCode");

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("API.Models.Entities.Employee", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CitizenId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("EmployeeStatus")
                        .HasColumnType("tinyint");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("API.Models.Entities.EmployeeCertificate", b =>
                {
                    b.Property<int>("No")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("No"));

                    b.Property<string>("CertificateCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("No");

                    b.HasIndex("CertificateCode");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeCertificates");
                });

            modelBuilder.Entity("API.Models.Entities.FeedingSchedule", b =>
                {
                    b.Property<int>("ScheduleNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleNo"));

                    b.Property<string>("AnimalId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("FeedQuantity")
                        .HasColumnType("int");

                    b.Property<byte>("FeedStatus")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("FeedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.HasKey("ScheduleNo");

                    b.HasIndex("AnimalId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("FoodId");

                    b.ToTable("FeedingSchedules");
                });

            modelBuilder.Entity("API.Models.Entities.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodId"));

                    b.Property<string>("FoodName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("FoodId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("API.Models.Entities.ImportHistory", b =>
                {
                    b.Property<int>("No")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("No"));

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ImportDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ImportQuantity")
                        .HasColumnType("int");

                    b.HasKey("No");

                    b.HasIndex("FoodId");

                    b.ToTable("ImportHistories");
                });

            modelBuilder.Entity("API.Models.Entities.News", b =>
                {
                    b.Property<int>("NewsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NewsId"));

                    b.Property<string>("AnimalId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<int>("SpeciesId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("WritingDate")
                        .HasColumnType("datetime2");

                    b.HasKey("NewsId");

                    b.HasIndex("AnimalId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("SpeciesId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("API.Models.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("API.Models.Entities.OrderDetail", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EntryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderDetailId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "TicketId");

                    b.HasIndex("TicketId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("API.Models.Entities.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"));

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("TicketId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("API.Models.Entities.TransactionHistory", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte?>("PaymentStatus")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("TransactionId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("TransactionHistories");
                });

            modelBuilder.Entity("API.Models.Entities.Animal", b =>
                {
                    b.HasOne("API.Models.Entities.Cage", "Cage")
                        .WithMany("Animals")
                        .HasForeignKey("CageId");

                    b.HasOne("API.Models.Entities.Employee", "Employee")
                        .WithMany("Animals")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("API.Models.Entities.AnimalSpecies", "AnimalSpecies")
                        .WithMany("Animals")
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnimalSpecies");

                    b.Navigation("Cage");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("API.Models.Entities.Cage", b =>
                {
                    b.HasOne("API.Models.Entities.Area", "Area")
                        .WithMany("Cages")
                        .HasForeignKey("AreaId");

                    b.Navigation("Area");
                });

            modelBuilder.Entity("API.Models.Entities.EmployeeCertificate", b =>
                {
                    b.HasOne("API.Models.Entities.Certificate", "Certificate")
                        .WithMany("EmployeeCertificates")
                        .HasForeignKey("CertificateCode");

                    b.HasOne("API.Models.Entities.Employee", "Employee")
                        .WithMany("EmployeeCertificates")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Certificate");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("API.Models.Entities.FeedingSchedule", b =>
                {
                    b.HasOne("API.Models.Entities.Animal", "Animal")
                        .WithMany("FeedingSchedules")
                        .HasForeignKey("AnimalId");

                    b.HasOne("API.Models.Entities.Employee", "Employee")
                        .WithMany("FeedingSchedules")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("API.Models.Entities.Food", "Food")
                        .WithMany("FeedingSchedules")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Employee");

                    b.Navigation("Food");
                });

            modelBuilder.Entity("API.Models.Entities.ImportHistory", b =>
                {
                    b.HasOne("API.Models.Entities.Food", "Food")
                        .WithMany("ImportHistories")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");
                });

            modelBuilder.Entity("API.Models.Entities.News", b =>
                {
                    b.HasOne("API.Models.Entities.Animal", "Animal")
                        .WithMany("News")
                        .HasForeignKey("AnimalId");

                    b.HasOne("API.Models.Entities.Employee", "Employee")
                        .WithMany("News")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("API.Models.Entities.AnimalSpecies", "AnimalSpecies")
                        .WithMany("News")
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("AnimalSpecies");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("API.Models.Entities.OrderDetail", b =>
                {
                    b.HasOne("API.Models.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Entities.Ticket", "Ticket")
                        .WithMany("OrderDetails")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("API.Models.Entities.TransactionHistory", b =>
                {
                    b.HasOne("API.Models.Entities.Order", "Order")
                        .WithOne("TransactionHistory")
                        .HasForeignKey("API.Models.Entities.TransactionHistory", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("API.Models.Entities.Animal", b =>
                {
                    b.Navigation("FeedingSchedules");

                    b.Navigation("News");
                });

            modelBuilder.Entity("API.Models.Entities.AnimalSpecies", b =>
                {
                    b.Navigation("Animals");

                    b.Navigation("News");
                });

            modelBuilder.Entity("API.Models.Entities.Area", b =>
                {
                    b.Navigation("Cages");
                });

            modelBuilder.Entity("API.Models.Entities.Cage", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("API.Models.Entities.Certificate", b =>
                {
                    b.Navigation("EmployeeCertificates");
                });

            modelBuilder.Entity("API.Models.Entities.Employee", b =>
                {
                    b.Navigation("Animals");

                    b.Navigation("EmployeeCertificates");

                    b.Navigation("FeedingSchedules");

                    b.Navigation("News");
                });

            modelBuilder.Entity("API.Models.Entities.Food", b =>
                {
                    b.Navigation("FeedingSchedules");

                    b.Navigation("ImportHistories");
                });

            modelBuilder.Entity("API.Models.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("TransactionHistory");
                });

            modelBuilder.Entity("API.Models.Entities.Ticket", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
