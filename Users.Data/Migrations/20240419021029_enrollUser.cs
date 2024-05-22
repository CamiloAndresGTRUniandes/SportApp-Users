using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Users.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class enrollUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "EnrollServiceUser",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserAsociateId",
                table: "EnrollServiceUser",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollServiceUser_UserAsociateId",
                table: "EnrollServiceUser",
                column: "UserAsociateId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollServiceUser_UserId",
                table: "EnrollServiceUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollServiceUser_AspNetUsers_UserAsociateId",
                table: "EnrollServiceUser",
                column: "UserAsociateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollServiceUser_AspNetUsers_UserId",
                table: "EnrollServiceUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnrollServiceUser_AspNetUsers_UserAsociateId",
                table: "EnrollServiceUser");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollServiceUser_AspNetUsers_UserId",
                table: "EnrollServiceUser");

            migrationBuilder.DropIndex(
                name: "IX_EnrollServiceUser_UserAsociateId",
                table: "EnrollServiceUser");

            migrationBuilder.DropIndex(
                name: "IX_EnrollServiceUser_UserId",
                table: "EnrollServiceUser");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "EnrollServiceUser",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserAsociateId",
                table: "EnrollServiceUser",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
