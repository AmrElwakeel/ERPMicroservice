using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Orders.BLL.Migrations
{
    public partial class updatedatatype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "Orders",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "OrderDetials",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "ItemPrice",
                table: "OrderDetials",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "OrderDetials",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ItemPrice", "TotalPrice" },
                values: new object[] { 250.0, 500.0 });

            migrationBuilder.UpdateData(
                table: "OrderDetials",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ItemPrice", "TotalPrice" },
                values: new object[] { 250.0, 500.0 });

            migrationBuilder.UpdateData(
                table: "OrderDetials",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "ItemPrice", "TotalPrice" },
                values: new object[] { 250.0, 500.0 });

            migrationBuilder.UpdateData(
                table: "OrderDetials",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "ItemPrice", "TotalPrice" },
                values: new object[] { 250.0, 500.0 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Created", "TotalPrice" },
                values: new object[] { new DateTime(2021, 2, 28, 0, 9, 34, 937, DateTimeKind.Local).AddTicks(2345), 1000.0 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Created", "TotalPrice" },
                values: new object[] { new DateTime(2021, 2, 28, 0, 9, 34, 937, DateTimeKind.Local).AddTicks(9762), 3000.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "OrderDetials",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "ItemPrice",
                table: "OrderDetials",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "OrderDetials",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ItemPrice", "TotalPrice" },
                values: new object[] { 250m, 500m });

            migrationBuilder.UpdateData(
                table: "OrderDetials",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ItemPrice", "TotalPrice" },
                values: new object[] { 250m, 500m });

            migrationBuilder.UpdateData(
                table: "OrderDetials",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "ItemPrice", "TotalPrice" },
                values: new object[] { 250m, 500m });

            migrationBuilder.UpdateData(
                table: "OrderDetials",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "ItemPrice", "TotalPrice" },
                values: new object[] { 250m, 500m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Created", "TotalPrice" },
                values: new object[] { new DateTime(2021, 2, 28, 0, 8, 5, 683, DateTimeKind.Local).AddTicks(8569), 1000m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Created", "TotalPrice" },
                values: new object[] { new DateTime(2021, 2, 28, 0, 8, 5, 684, DateTimeKind.Local).AddTicks(6101), 3000m });
        }
    }
}
