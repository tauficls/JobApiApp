using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobTitles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Level = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobPositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ParentId = table.Column<Guid>(type: "TEXT", nullable: true),
                    JobTitleId = table.Column<Guid>(type: "TEXT", nullable: true),
                    OrganizationId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobPositions_JobPositions_ParentId",
                        column: x => x.ParentId,
                        principalTable: "JobPositions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobPositions_JobTitles_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitles",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "JobTitles",
                columns: new[] { "Id", "Code", "Description", "Level" },
                values: new object[,]
                {
                    { new Guid("0190e8dd-0225-725f-8099-93fb2b33a906"), "123", "Junior", 1 },
                    { new Guid("0190e8dd-0225-7260-800e-9118cdb9d783"), "100", "Senior", 2 },
                    { new Guid("0190e8dd-0225-7261-ae42-f896cde1f13b"), "200", "Lead", 3 }
                });

            migrationBuilder.InsertData(
                table: "JobPositions",
                columns: new[] { "Id", "Code", "Description", "JobTitleId", "OrganizationId", "ParentId" },
                values: new object[,]
                {
                    { new Guid("0190ee35-367b-712b-9454-5e82dcd9de07"), "101", "BackEnd", new Guid("0190e8dd-0225-725f-8099-93fb2b33a906"), null, null },
                    { new Guid("0190ee35-367b-712c-a960-4e6eeab84c67"), "102", "BackEnd", new Guid("0190e8dd-0225-7260-800e-9118cdb9d783"), null, null },
                    { new Guid("0190ee35-367b-712d-8b56-ef01144c8ea8"), "103", "BackEnd", new Guid("0190e8dd-0225-7261-ae42-f896cde1f13b"), null, null },
                    { new Guid("0190ee35-367b-712e-9910-cbc19415d184"), "201", "FrontEnd", new Guid("0190e8dd-0225-725f-8099-93fb2b33a906"), null, null },
                    { new Guid("0190ee35-367b-712f-9b04-a67110923043"), "202", "FrontEnd", new Guid("0190e8dd-0225-7260-800e-9118cdb9d783"), null, null },
                    { new Guid("0190ee35-367b-7130-8d57-a015be40a3b0"), "203", "FrontEnd", new Guid("0190e8dd-0225-7261-ae42-f896cde1f13b"), null, null },
                    { new Guid("0190ee35-367b-7131-a1cc-db680ebe30ee"), "301", "FullStack", new Guid("0190e8dd-0225-725f-8099-93fb2b33a906"), null, null },
                    { new Guid("0190ee35-367b-7132-894e-627a49786576"), "302", "FullStack", new Guid("0190e8dd-0225-7260-800e-9118cdb9d783"), null, null },
                    { new Guid("0190ee35-367b-7133-958c-d4e8536d528d"), "303", "FullStack", new Guid("0190e8dd-0225-7261-ae42-f896cde1f13b"), null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobPositions_JobTitleId",
                table: "JobPositions",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPositions_ParentId",
                table: "JobPositions",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobPositions");

            migrationBuilder.DropTable(
                name: "JobTitles");
        }
    }
}
