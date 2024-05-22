using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Users.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class wasPayed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "wasPayed",
                table: "EnrollServiceUser",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "wasPayed",
                table: "EnrollServiceUser");
        }
    }
}
