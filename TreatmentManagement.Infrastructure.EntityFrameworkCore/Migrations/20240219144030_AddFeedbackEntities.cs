using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AddFeedbackEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseGuideReference_Exercises_ExerciseId",
                schema: "TM",
                table: "ExerciseGuideReference");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDetailWeekDay_PlanDetails_PlanDetailId",
                schema: "TM",
                table: "PlanDetailWeekDay");

            migrationBuilder.CreateTable(
                name: "CollectionFeedbacks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    PlanId = table.Column<long>(type: "bigint", nullable: false),
                    CollectionId = table.Column<long>(type: "bigint", nullable: false),
                    DoingState = table.Column<bool>(type: "bit", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionFeedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollectionFeedbacks_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionFeedbacks_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalSchema: "TM",
                        principalTable: "Collections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CollectionFeedbacks_Plans_PlanId",
                        column: x => x.PlanId,
                        principalSchema: "TM",
                        principalTable: "Plans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExerciseFeedbacks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    PlanId = table.Column<long>(type: "bigint", nullable: false),
                    ExerciseId = table.Column<long>(type: "bigint", nullable: false),
                    DoingState = table.Column<bool>(type: "bit", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseFeedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseFeedbacks_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseFeedbacks_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalSchema: "TM",
                        principalTable: "Exercises",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExerciseFeedbacks_Plans_PlanId",
                        column: x => x.PlanId,
                        principalSchema: "TM",
                        principalTable: "Plans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionFeedbacks_CollectionId",
                table: "CollectionFeedbacks",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionFeedbacks_PlanId",
                table: "CollectionFeedbacks",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseFeedbacks_ExerciseId",
                table: "ExerciseFeedbacks",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseFeedbacks_PlanId",
                table: "ExerciseFeedbacks",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseGuideReference_Exercises_ExerciseId",
                schema: "TM",
                table: "ExerciseGuideReference",
                column: "ExerciseId",
                principalSchema: "TM",
                principalTable: "Exercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDetailWeekDay_PlanDetails_PlanDetailId",
                schema: "TM",
                table: "PlanDetailWeekDay",
                column: "PlanDetailId",
                principalSchema: "TM",
                principalTable: "PlanDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseGuideReference_Exercises_ExerciseId",
                schema: "TM",
                table: "ExerciseGuideReference");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDetailWeekDay_PlanDetails_PlanDetailId",
                schema: "TM",
                table: "PlanDetailWeekDay");

            migrationBuilder.DropTable(
                name: "CollectionFeedbacks");

            migrationBuilder.DropTable(
                name: "ExerciseFeedbacks");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseGuideReference_Exercises_ExerciseId",
                schema: "TM",
                table: "ExerciseGuideReference",
                column: "ExerciseId",
                principalSchema: "TM",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDetailWeekDay_PlanDetails_PlanDetailId",
                schema: "TM",
                table: "PlanDetailWeekDay",
                column: "PlanDetailId",
                principalSchema: "TM",
                principalTable: "PlanDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
