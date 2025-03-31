using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFridge.Database;

public class UserIngredientsDbContext : DbContext
{
    public DbSet<Ingredient> Ingrediente { get; set; } = default!;

    public UserIngredientsDbContext(DbContextOptions<UserIngredientsDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ingredient>().HasData(
            new Ingredient { Id = 1, Nume = "Oua", Calorii = 155, Proteine = 13, Grasimi = 11, Carbohidrati = 1, DataExpirare = DateTime.Now.AddDays(10) },
            new Ingredient { Id = 2, Nume = "Lapte", Calorii = 42, Proteine = 3.4, Grasimi = 1, Carbohidrati = 5, DataExpirare = DateTime.Now.AddDays(5) }
        );
    }
}

public class Ingredient
{
    public int Id { get; set; }
    public string? Nume { get; set; }
    public int Calorii { get; set; }
    public double Proteine { get; set; }
    public double Grasimi { get; set; }
    public double Carbohidrati { get; set; }
    public DateTime DataExpirare { get; set; }
}
