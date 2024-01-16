using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialTM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TM");

            migrationBuilder.CreateTable(
                name: "BaseEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollectionCategories",
                schema: "TM",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollectionCategories_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionCategories_CollectionCategories_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "TM",
                        principalTable: "CollectionCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                schema: "TM",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: false),
                    LongDescription = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true),
                    IsGlobal = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collections_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseCategories",
                schema: "TM",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseCategories_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseCategories_ExerciseCategories_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "TM",
                        principalTable: "ExerciseCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                schema: "TM",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: false),
                    LongDescription = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true),
                    IsGlobal = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                schema: "TM",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true),
                    ExpertId = table.Column<long>(type: "bigint", nullable: false),
                    ClientId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plans_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollectionCollectionCategory",
                schema: "TM",
                columns: table => new
                {
                    CategoriesId = table.Column<long>(type: "bigint", nullable: false),
                    CollectionsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionCollectionCategory", x => new { x.CategoriesId, x.CollectionsId });
                    table.ForeignKey(
                        name: "FK_CollectionCollectionCategory_CollectionCategories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalSchema: "TM",
                        principalTable: "CollectionCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CollectionCollectionCategory_Collections_CollectionsId",
                        column: x => x.CollectionsId,
                        principalSchema: "TM",
                        principalTable: "Collections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CollectionDetails",
                schema: "TM",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CollectionId = table.Column<long>(type: "bigint", nullable: false),
                    ExerciseId = table.Column<long>(type: "bigint", nullable: false),
                    NumberPerDuration = table.Column<long>(type: "bigint", nullable: false),
                    SecondsOfDuration = table.Column<long>(type: "bigint", nullable: false),
                    Priority = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollectionDetails_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionDetails_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalSchema: "TM",
                        principalTable: "Collections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CollectionDetails_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalSchema: "TM",
                        principalTable: "Exercises",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExerciseExerciseCategory",
                schema: "TM",
                columns: table => new
                {
                    CategoriesId = table.Column<long>(type: "bigint", nullable: false),
                    ExercisesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseExerciseCategory", x => new { x.CategoriesId, x.ExercisesId });
                    table.ForeignKey(
                        name: "FK_ExerciseExerciseCategory_ExerciseCategories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalSchema: "TM",
                        principalTable: "ExerciseCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExerciseExerciseCategory_Exercises_ExercisesId",
                        column: x => x.ExercisesId,
                        principalSchema: "TM",
                        principalTable: "Exercises",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExerciseFiles",
                schema: "TM",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ExerciseId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseFiles_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseFiles_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalSchema: "TM",
                        principalTable: "Exercises",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExerciseGuideReference",
                schema: "TM",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseGuideReference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseGuideReference_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalSchema: "TM",
                        principalTable: "Exercises",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlanDetails",
                schema: "TM",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    PlanId = table.Column<long>(type: "bigint", nullable: false),
                    CollectionId = table.Column<long>(type: "bigint", nullable: false),
                    Priority = table.Column<long>(type: "bigint", nullable: false),
                    StartCollection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndCollection = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanDetails_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanDetails_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalSchema: "TM",
                        principalTable: "Collections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanDetails_Plans_PlanId",
                        column: x => x.PlanId,
                        principalSchema: "TM",
                        principalTable: "Plans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlanDetailWeekDay",
                schema: "TM",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanDetailId = table.Column<long>(type: "bigint", nullable: false),
                    DayOfWeek = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanDetailWeekDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanDetailWeekDay_PlanDetails_PlanDetailId",
                        column: x => x.PlanDetailId,
                        principalSchema: "TM",
                        principalTable: "PlanDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionCategories_ParentId",
                schema: "TM",
                table: "CollectionCategories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionCollectionCategory_CollectionsId",
                schema: "TM",
                table: "CollectionCollectionCategory",
                column: "CollectionsId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionDetails_CollectionId",
                schema: "TM",
                table: "CollectionDetails",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionDetails_ExerciseId",
                schema: "TM",
                table: "CollectionDetails",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseCategories_ParentId",
                schema: "TM",
                table: "ExerciseCategories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseExerciseCategory_ExercisesId",
                schema: "TM",
                table: "ExerciseExerciseCategory",
                column: "ExercisesId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseFiles_ExerciseId",
                schema: "TM",
                table: "ExerciseFiles",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseGuideReference_ExerciseId",
                schema: "TM",
                table: "ExerciseGuideReference",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDetails_CollectionId",
                schema: "TM",
                table: "PlanDetails",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDetails_PlanId",
                schema: "TM",
                table: "PlanDetails",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDetailWeekDay_PlanDetailId",
                schema: "TM",
                table: "PlanDetailWeekDay",
                column: "PlanDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionCollectionCategory",
                schema: "TM");

            migrationBuilder.DropTable(
                name: "CollectionDetails",
                schema: "TM");

            migrationBuilder.DropTable(
                name: "ExerciseExerciseCategory",
                schema: "TM");

            migrationBuilder.DropTable(
                name: "ExerciseFiles",
                schema: "TM");

            migrationBuilder.DropTable(
                name: "ExerciseGuideReference",
                schema: "TM");

            migrationBuilder.DropTable(
                name: "PlanDetailWeekDay",
                schema: "TM");

            migrationBuilder.DropTable(
                name: "CollectionCategories",
                schema: "TM");

            migrationBuilder.DropTable(
                name: "ExerciseCategories",
                schema: "TM");

            migrationBuilder.DropTable(
                name: "Exercises",
                schema: "TM");

            migrationBuilder.DropTable(
                name: "PlanDetails",
                schema: "TM");

            migrationBuilder.DropTable(
                name: "Collections",
                schema: "TM");

            migrationBuilder.DropTable(
                name: "Plans",
                schema: "TM");

            migrationBuilder.DropTable(
                name: "BaseEntity");
        }
    }
}
