using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Users.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class addMigrationPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Plan",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Enabled", "Name", "Price", "UpdateAt", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("2c312559-173d-4239-a03d-2fdb3f219fa5"), null, "3bfc0e87-e3bb-46b4-9f0a-b0d264fcd6b6", "Intermediate  Plan", true, "Intermediate", 0m, null, null },
                    { new Guid("672d4087-ac82-42b5-846e-64905d1a09b3"), null, "3bfc0e87-e3bb-46b4-9f0a-b0d264fcd6b6", "Basic  Plan", true, "Basic", 0m, null, null },
                    { new Guid("7ee7db76-77c2-4353-a509-ebe4fbe4aed4"), null, "3bfc0e87-e3bb-46b4-9f0a-b0d264fcd6b6", "Premium  Plan", true, "Premium", 0m, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("2c312559-173d-4239-a03d-2fdb3f219fa5"));

            migrationBuilder.DeleteData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("672d4087-ac82-42b5-846e-64905d1a09b3"));

            migrationBuilder.DeleteData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("7ee7db76-77c2-4353-a509-ebe4fbe4aed4"));
        }
    }
}
