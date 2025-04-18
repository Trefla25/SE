﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartFridge.Database;

#nullable disable

namespace SmartFridge.Migrations
{
    [Migration("20250325173416_InitialCreate")]
    partial class InitialCreate
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
                });
#pragma warning restore 612, 618
        }
    }
}
