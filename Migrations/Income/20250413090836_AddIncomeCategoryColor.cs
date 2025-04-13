using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance_Monitor.Migrations.Income
{
    /// <inheritdoc />
    public partial class AddIncomeCategoryColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ColorHex",
                table: "IncomeCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorHex",
                table: "IncomeCategories");
        }
    }
}
