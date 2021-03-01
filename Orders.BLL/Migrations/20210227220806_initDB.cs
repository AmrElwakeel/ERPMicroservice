using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Orders.BLL.Migrations
{
    public partial class initDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetials",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ItemPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetials", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderDetials_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID", "Created", "IsDeleted", "TotalPrice", "Updated" },
                values: new object[] { 1, new DateTime(2021, 2, 28, 0, 8, 5, 683, DateTimeKind.Local).AddTicks(8569), false, 1000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID", "Created", "IsDeleted", "TotalPrice", "Updated" },
                values: new object[] { 2, new DateTime(2021, 2, 28, 0, 8, 5, 684, DateTimeKind.Local).AddTicks(6101), false, 3000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "OrderDetials",
                columns: new[] { "ID", "Amount", "ItemPrice", "OrderId", "ProductId", "ProductName", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 2, 250m, 1, 1, "IPhone", 500m },
                    { 2, 2, 250m, 1, 2, "MI 10T", 500m },
                    { 3, 2, 250m, 2, 1, "IPhone", 500m },
                    { 4, 2, 250m, 2, 2, "MI 10T", 500m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetials_OrderId",
                table: "OrderDetials",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetials");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
