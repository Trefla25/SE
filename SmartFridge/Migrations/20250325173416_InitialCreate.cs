using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFridge.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    Carbohidrati = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Retete",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nume = table.Column<string>(type: "TEXT", nullable: true),
                    IngredienteNecesare = table.Column<string>(type: "TEXT", nullable: true),
                    CaloriiTotal = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retete", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingrediente");

            migrationBuilder.DropTable(
                name: "Retete");
        }
    }
}
