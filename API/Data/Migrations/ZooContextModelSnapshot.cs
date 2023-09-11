﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Data.Migrations
{
    [DbContext(typeof(ZooContext))]
    partial class ZooContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("API.Entities.Animal", b =>
                {
                    b.Property<int>("animalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("animalName")
                        .HasColumnType("TEXT");

                    b.Property<string>("birthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<string>("gender")
                        .HasColumnType("TEXT");

                    b.Property<bool>("healthCheck")
                        .HasColumnType("INTEGER");

                    b.Property<string>("rarity")
                        .HasColumnType("TEXT");

                    b.Property<string>("region")
                        .HasColumnType("TEXT");

                    b.HasKey("animalID");

                    b.ToTable("Animals");
                });
#pragma warning restore 612, 618
        }
    }
}
