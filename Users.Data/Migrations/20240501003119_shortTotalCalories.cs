using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Users.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class shortTotalCalories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalCalories",
                table: "RecordTrainingSession",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCalories",
                table: "RecordTrainingSession",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
