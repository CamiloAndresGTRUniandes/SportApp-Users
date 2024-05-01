using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Users.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class changeTypeOfDataTotalTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TotalTime",
                table: "RecordTrainingSession",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TotalTime",
                table: "RecordTrainingSession",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }
    }
}
