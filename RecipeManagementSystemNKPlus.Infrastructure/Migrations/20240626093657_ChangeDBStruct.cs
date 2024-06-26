using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeManagementSystemNKPlus.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDBStruct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Composites");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Composites",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
