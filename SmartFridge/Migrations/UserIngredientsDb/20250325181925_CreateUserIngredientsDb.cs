using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFridge.Migrations.UserIngredientsDb
{
    /// <inheritdoc />
    public partial class CreateUserIngredientsDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingrediente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nume = table.Column<string>(type: "TEXT", nullable: true),
                    Calorii = table.Column<int>(type: "INTEGER", nullable: false),
                    Proteine = table.Column<double>(type: "REAL", nullable: false),
                    Grasimi = table.Column<double>(type: "REAL", nullable: false),
                    Carbohidrati = table.Column<double>(type: "REAL", nullable: false),
                    DataExpirare = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediente", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingrediente");
        }
    }
}
