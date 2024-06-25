using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeManagementSystemNKPlus.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRetalationProdComposite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductComposite",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CompositeId = table.Column<int>(type: "int", nullable: false),
                    CompositeTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductComposite", x => new { x.ProductId, x.CompositeId });
                    table.ForeignKey(
                        name: "FK_ProductComposite_CompositeTypes_CompositeTypeId",
                        column: x => x.CompositeTypeId,
                        principalTable: "CompositeTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductComposite_Composites_CompositeId",
                        column: x => x.CompositeId,
                        principalTable: "Composites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductComposite_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductComposite_CompositeId",
                table: "ProductComposite",
                column: "CompositeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComposite_CompositeTypeId",
                table: "ProductComposite",
                column: "CompositeTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductComposite");

            migrationBuilder.CreateTable(
                name: "ProductCompositeTypes",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CompositeTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCompositeTypes", x => new { x.ProductId, x.CompositeTypeId });
                    table.ForeignKey(
                        name: "FK_ProductCompositeTypes_CompositeTypes_CompositeTypeId",
                        column: x => x.CompositeTypeId,
                        principalTable: "CompositeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCompositeTypes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCompositeTypes_CompositeTypeId",
                table: "ProductCompositeTypes",
                column: "CompositeTypeId");
        }
    }
}
