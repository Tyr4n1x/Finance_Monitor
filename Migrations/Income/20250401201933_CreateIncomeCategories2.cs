using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance_Monitor.Migrations.Income
{
    /// <inheritdoc />
    public partial class CreateIncomeCategories2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncomeCategories_Incomes_IncomeId",
                table: "IncomeCategories");

            migrationBuilder.DropIndex(
                name: "IX_IncomeCategories_IncomeId",
                table: "IncomeCategories");

            migrationBuilder.DropColumn(
                name: "IncomeId",
                table: "IncomeCategories");

            migrationBuilder.AddColumn<string>(
                name: "Categories",
                table: "Incomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categories",
                table: "Incomes");

            migrationBuilder.AddColumn<int>(
                name: "IncomeId",
                table: "IncomeCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IncomeCategories_IncomeId",
                table: "IncomeCategories",
                column: "IncomeId");

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeCategories_Incomes_IncomeId",
                table: "IncomeCategories",
                column: "IncomeId",
                principalTable: "Incomes",
                principalColumn: "Id");
        }
    }
}
