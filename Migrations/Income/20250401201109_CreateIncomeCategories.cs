using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance_Monitor.Migrations.Income
{
    /// <inheritdoc />
    public partial class CreateIncomeCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Income",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "Categories",
                table: "Income");

            migrationBuilder.RenameTable(
                name: "Income",
                newName: "Incomes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Incomes",
                table: "Incomes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "IncomeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncomeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeCategories_Incomes_IncomeId",
                        column: x => x.IncomeId,
                        principalTable: "Incomes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IncomeCategories_IncomeId",
                table: "IncomeCategories",
                column: "IncomeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncomeCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Incomes",
                table: "Incomes");

            migrationBuilder.RenameTable(
                name: "Incomes",
                newName: "Income");

            migrationBuilder.AddColumn<string>(
                name: "Categories",
                table: "Income",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Income",
                table: "Income",
                column: "Id");
        }
    }
}
