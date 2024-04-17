using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class ChangeManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsTags");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "126d4268-ea41-4dab-af6a-5d80409fe411");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c110bc8-d87a-45ca-8590-9524f19486ba");

            migrationBuilder.CreateTable(
                name: "ProductsTagsComparer",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsTagsComparer", x => new { x.ProductsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_ProductsTagsComparer_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsTagsComparer_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c903fc7-dd16-4641-825e-8a08d495ebcc", null, "Admin", "ADMIN" },
                    { "a45904ba-95ca-4252-acd7-6a4c5a303e33", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsTagsComparer_TagsId",
                table: "ProductsTagsComparer",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsTagsComparer");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c903fc7-dd16-4641-825e-8a08d495ebcc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a45904ba-95ca-4252-acd7-6a4c5a303e33");

            migrationBuilder.CreateTable(
                name: "ProductsTags",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsTags", x => new { x.ProductId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ProductsTags_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "126d4268-ea41-4dab-af6a-5d80409fe411", null, "Admin", "ADMIN" },
                    { "9c110bc8-d87a-45ca-8590-9524f19486ba", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsTags_TagId",
                table: "ProductsTags",
                column: "TagId");
        }
    }
}
