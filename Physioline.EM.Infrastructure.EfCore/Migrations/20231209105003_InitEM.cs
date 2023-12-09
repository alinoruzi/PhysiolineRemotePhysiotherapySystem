using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Physioline.EM.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class InitEM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "EM");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "EM",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Descriptin = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "EM",
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                schema: "EM",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Picture_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture_FileExtention = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Video_Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Video_FileExtention = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseCategories",
                schema: "EM",
                columns: table => new
                {
                    ExerciseId = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseCategories", x => new { x.ExerciseId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ExerciseCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "EM",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseCategories_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalSchema: "EM",
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseGuide",
                schema: "EM",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Link = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseGuide", x => new { x.ExerciseId, x.Id });
                    table.ForeignKey(
                        name: "FK_ExerciseGuide_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalSchema: "EM",
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                schema: "EM",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseCategories_CategoryId",
                schema: "EM",
                table: "ExerciseCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseCategories",
                schema: "EM");

            migrationBuilder.DropTable(
                name: "ExerciseGuide",
                schema: "EM");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "EM");

            migrationBuilder.DropTable(
                name: "Exercises",
                schema: "EM");
        }
    }
}
