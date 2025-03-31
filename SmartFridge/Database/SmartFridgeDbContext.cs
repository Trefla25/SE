using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFridge.Database;

public class SmartFridgeDbContext : DbContext
{
    public DbSet<Reteta> Retete { get; set; } = default!;

    public SmartFridgeDbContext(DbContextOptions<SmartFridgeDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reteta>().HasData(
            new Reteta { Id = 1, Nume = "Clătite", IngredienteNecesare = "Oua, Lapte, Faina", CaloriiTotal = 500 },
            new Reteta { Id = 2, Nume = "Omletă", IngredienteNecesare = "Oua, Lapte", CaloriiTotal = 250 }
        );
    }
}

public class Reteta
{
    public int Id { get; set; }
    public string Nume { get; set; } = default!;
    public string IngredienteNecesare { get; set; } = default!;
    public int CaloriiTotal { get; set; }
}

