﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartFridge.Database;

#nullable disable

namespace SmartFridge.Migrations.UserIngredientsDb
{
    [DbContext(typeof(UserIngredientsDbContext))]
    [Migration("20250325181925_CreateUserIngredientsDb")]
    partial class CreateUserIngredientsDb
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

                    b.Property<DateTime>("DataExpirare")
                        .HasColumnType("TEXT");

                    b.Property<double>("Grasimi")
                        .HasColumnType("REAL");

                    b.Property<string>("Nume")
                        .HasColumnType("TEXT");

                    b.Property<double>("Proteine")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Ingrediente");
                });
#pragma warning restore 612, 618
        }
    }
}
