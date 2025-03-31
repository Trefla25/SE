using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartFridge.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingrediente",
                columns: new[] { "Id", "Calorii", "Carbohidrati", "Grasimi", "Nume", "Proteine" },
                values: new object[,]
                {
                    { 1, 155, 1.0, 11.0, "Oua", 13.0 },
                    { 2, 42, 5.0, 1.0, "Lapte", 3.3999999999999999 },
                    { 3, 364, 76.0, 1.0, "Faina", 10.0 }
                });

            migrationBuilder.InsertData(
                table: "Retete",
                columns: new[] { "Id", "CaloriiTotal", "IngredienteNecesare", "Nume" },
                values: new object[,]
                {
                    { 1, 500, "Oua, Lapte, Faina", "Clatite" },
                    { 2, 250, "Oua, Lapte", "Omleta" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Retete",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Retete",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
