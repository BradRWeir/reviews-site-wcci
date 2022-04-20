using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace template_csharp_reviews_site.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OSVer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Processor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RamSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Storage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Model", "OSVer", "Picture", "Price", "Processor", "RamSize", "ReleaseDate", "Storage" },
                values: new object[,]
                {
                    { 1, "Samsung", "Galaxy", "Android 10", "https://th.bing.com/th/id/OIP.KaKM93VZeh0ZQH0ylnub2gHaHa?pid=ImgDet&rs=1", 800.0, "Snap Dragon", "256GB", new DateTime(2022, 2, 23, 17, 16, 59, 941, DateTimeKind.Local).AddTicks(7881), "512GB" },
                    { 2, "Apple", "iPhone 13 Pro Max", "iOS", "https://th.bing.com/th/id/R.708c4252d828ae9a7f2eb797f7577b30?rik=4b1OYH%2bB6nrH2g&pid=ImgRaw&r=0", 1099.0, "Snap Dragon", "256GB", new DateTime(2022, 2, 23, 17, 16, 59, 949, DateTimeKind.Local).AddTicks(4665), "512GB" },
                    { 3, "Motorola", "Razr", "Android 9", "https://th.bing.com/th/id/OIP.oMxlQYNUc6msuFWHGQOglgHaHc?pid=ImgDet&rs=1", 499.0, "Snap Dragon", "256GB", new DateTime(2022, 2, 23, 17, 16, 59, 949, DateTimeKind.Local).AddTicks(4849), "512GB" },
                    { 4, "GooglePhone", "Pixel 6 Pro", "Android 12", "https://touchit.sk/wp-content/uploads/2021/05/google_pixel_6_6_pro_duo_nowat.jpg", 599.0, "Snap Dragon", "256GB", new DateTime(2022, 2, 23, 17, 16, 59, 949, DateTimeKind.Local).AddTicks(4878), "512GB" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Content", "ProductId", "Rating", "ReviewDate", "Title", "UserName" },
                values: new object[,]
                {
                    { 1, "I love it.", 1, 5, new DateTime(2022, 2, 23, 17, 16, 59, 949, DateTimeKind.Local).AddTicks(5838), "Great.", "Lisa" },
                    { 5, "I love it.", 1, 5, new DateTime(2022, 2, 23, 17, 16, 59, 949, DateTimeKind.Local).AddTicks(8411), "Great.", "Donna" },
                    { 2, "I love it.", 2, 5, new DateTime(2022, 2, 23, 17, 16, 59, 949, DateTimeKind.Local).AddTicks(8342), "Great.", "Norm" },
                    { 3, "I love it.", 3, 5, new DateTime(2022, 2, 23, 17, 16, 59, 949, DateTimeKind.Local).AddTicks(8384), "Great.", "Chaz" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
