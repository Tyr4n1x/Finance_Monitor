using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance_Monitor.Migrations.Expense
{
    /// <inheritdoc />
    public partial class AddExpenseCategoryColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ColorHex",
                table: "ExpenseCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorHex",
                table: "ExpenseCategories");
        }
    }
}
