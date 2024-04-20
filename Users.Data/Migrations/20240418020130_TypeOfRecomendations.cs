using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Users.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class TypeOfRecomendations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TypeOfRecommendationId",
                table: "UserRecommendation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TypeOfRecommendation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfRecommendation", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TypeOfRecommendation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Enabled", "Name", "UpdateAt", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("0037fc1b-5414-449c-8f68-ff9d7365f1a0"), null, "System", false, "Recomendacion", null, null },
                    { new Guid("7707e9fa-14cb-4067-a2b0-73437dd87e36"), null, "System", false, "Nutricional", null, null },
                    { new Guid("f3510145-7a12-448a-b4ae-9cf65dfce907"), null, "System", false, "Seguimiento de ejercicio", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRecommendation_TypeOfRecommendationId",
                table: "UserRecommendation",
                column: "TypeOfRecommendationId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecommendation_TypeOfRecommendation_TypeOfRecommendationId",
                table: "UserRecommendation",
                column: "TypeOfRecommendationId",
                principalTable: "TypeOfRecommendation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRecommendation_TypeOfRecommendation_TypeOfRecommendationId",
                table: "UserRecommendation");

            migrationBuilder.DropTable(
                name: "TypeOfRecommendation");

            migrationBuilder.DropIndex(
                name: "IX_UserRecommendation_TypeOfRecommendationId",
                table: "UserRecommendation");

            migrationBuilder.DropColumn(
                name: "TypeOfRecommendationId",
                table: "UserRecommendation");
        }
    }
}
