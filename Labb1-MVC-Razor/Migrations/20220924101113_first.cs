using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb1_MVC_Razor.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentBooks",
                columns: table => new
                {
                    RentBookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentBooks", x => x.RentBookId);
                    table.ForeignKey(
                        name: "FK_RentBooks_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentBookDetails",
                columns: table => new
                {
                    RentBookDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentBookId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentBookDetails", x => x.RentBookDetailId);
                    table.ForeignKey(
                        name: "FK_RentBookDetails_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentBookDetails_RentBooks_RentBookId",
                        column: x => x.RentBookId,
                        principalTable: "RentBooks",
                        principalColumn: "RentBookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Amount", "Description", "Title" },
                values: new object[] { 1, 10, "En saga", "Hobbit 1" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Amount", "Description", "Title" },
                values: new object[] { 2, 5, "En saga om", "Hobbit 2" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Amount", "Description", "Title" },
                values: new object[] { 3, 10, "En saga om något", "Hobbit 3" });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_BookId",
                table: "CartItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_RentBookDetails_BookId",
                table: "RentBookDetails",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_RentBookDetails_RentBookId",
                table: "RentBookDetails",
                column: "RentBookId");

            migrationBuilder.CreateIndex(
                name: "IX_RentBooks_CustomerId",
                table: "RentBooks",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "RentBookDetails");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "RentBooks");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
