using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeManagementSystemNKPlus.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRetalationProdComposite1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductComposite_CompositeTypes_CompositeTypeId",
                table: "ProductComposite");

            migrationBuilder.DropIndex(
                name: "IX_ProductComposite_CompositeTypeId",
                table: "ProductComposite");

            migrationBuilder.DropColumn(
                name: "CompositeTypeId",
                table: "ProductComposite");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompositeTypeId",
                table: "ProductComposite",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductComposite_CompositeTypeId",
                table: "ProductComposite",
                column: "CompositeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductComposite_CompositeTypes_CompositeTypeId",
                table: "ProductComposite",
                column: "CompositeTypeId",
                principalTable: "CompositeTypes",
                principalColumn: "Id");
        }
    }
}
