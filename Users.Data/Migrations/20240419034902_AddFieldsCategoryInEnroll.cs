using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Users.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsCategoryInEnroll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "EnrollServiceUser",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "EnrollServiceUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("2c312559-173d-4239-a03d-2fdb3f219fa5"),
                column: "Price",
                value: 50m);

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("7ee7db76-77c2-4353-a509-ebe4fbe4aed4"),
                column: "Price",
                value: 150m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "EnrollServiceUser");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "EnrollServiceUser");

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("2c312559-173d-4239-a03d-2fdb3f219fa5"),
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("7ee7db76-77c2-4353-a509-ebe4fbe4aed4"),
                column: "Price",
                value: 0m);
        }
    }
}
