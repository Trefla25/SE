﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartFridge.Database;

#nullable disable

namespace SmartFridge.Migrations
{
    [Migration("20250325175636_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("SmartFridge.Database.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Calorii")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Carbohidrati")
                        .HasColumnType("REAL");

                    b.Property<double>("Grasimi")
                        .HasColumnType("REAL");

                    b.Property<string>("Nume")
                        .HasColumnType("TEXT");

                    b.Property<double>("Proteine")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Ingrediente");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Calorii = 155,
                            Carbohidrati = 1.0,
                            Grasimi = 11.0,
                            Nume = "Oua",
                            Proteine = 13.0
                        },
                        new
                        {
                            Id = 2,
                            Calorii = 42,
                            Carbohidrati = 5.0,
                            Grasimi = 1.0,
                            Nume = "Lapte",
                            Proteine = 3.3999999999999999
                        },
                        new
                        {
                            Id = 3,
                            Calorii = 364,
                            Carbohidrati = 76.0,
                            Grasimi = 1.0,
                            Nume = "Faina",
                            Proteine = 10.0
                        });
                });

            modelBuilder.Entity("SmartFridge.Database.Reteta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CaloriiTotal")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IngredienteNecesare")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nume")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Retete");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CaloriiTotal = 500,
                            IngredienteNecesare = "Oua, Lapte, Faina",
                            Nume = "Clatite"
                        },
                        new
                        {
                            Id = 2,
                            CaloriiTotal = 250,
                            IngredienteNecesare = "Oua, Lapte",
                            Nume = "Omleta"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
