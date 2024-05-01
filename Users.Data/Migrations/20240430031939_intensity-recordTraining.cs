using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Users.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class intensityrecordTraining : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Intensity",
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
                    table.PrimaryKey("PK_Intensity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecordTrainingSession",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalCalories = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IntensityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FTP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordTrainingSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecordTrainingSession_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecordTrainingSession_Intensity_IntensityId",
                        column: x => x.IntensityId,
                        principalTable: "Intensity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Intensity",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Enabled", "Name", "UpdateAt", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("033e6b36-38a2-4457-b5ba-0b113a5fafed"), null, null, true, "Media", null, null },
                    { new Guid("267939ec-5810-4913-bfc3-f02edd79c144"), null, null, true, "Alta", null, null },
                    { new Guid("f0fa1aca-0936-4de6-90c0-96add874e03e"), null, null, true, "Baja", null, null }
                });

            migrationBuilder.UpdateData(
                table: "TypeOfRecommendation",
                keyColumn: "Id",
                keyValue: new Guid("0037fc1b-5414-449c-8f68-ff9d7365f1a0"),
                column: "Enabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "TypeOfRecommendation",
                keyColumn: "Id",
                keyValue: new Guid("7707e9fa-14cb-4067-a2b0-73437dd87e36"),
                column: "Enabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "TypeOfRecommendation",
                keyColumn: "Id",
                keyValue: new Guid("f3510145-7a12-448a-b4ae-9cf65dfce907"),
                column: "Enabled",
                value: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecordTrainingSession_IntensityId",
                table: "RecordTrainingSession",
                column: "IntensityId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordTrainingSession_UserId",
                table: "RecordTrainingSession",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecordTrainingSession");

            migrationBuilder.DropTable(
                name: "Intensity");

            migrationBuilder.UpdateData(
                table: "TypeOfRecommendation",
                keyColumn: "Id",
                keyValue: new Guid("0037fc1b-5414-449c-8f68-ff9d7365f1a0"),
                column: "Enabled",
                value: false);

            migrationBuilder.UpdateData(
                table: "TypeOfRecommendation",
                keyColumn: "Id",
                keyValue: new Guid("7707e9fa-14cb-4067-a2b0-73437dd87e36"),
                column: "Enabled",
                value: false);

            migrationBuilder.UpdateData(
                table: "TypeOfRecommendation",
                keyColumn: "Id",
                keyValue: new Guid("f3510145-7a12-448a-b4ae-9cf65dfce907"),
                column: "Enabled",
                value: false);
        }
    }
}
