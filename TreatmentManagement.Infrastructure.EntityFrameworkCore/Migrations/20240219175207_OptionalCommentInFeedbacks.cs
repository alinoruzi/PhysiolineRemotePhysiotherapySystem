using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreatmentManagement.Infrastructure.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class OptionalCommentInFeedbacks : Migration
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

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "ExerciseFeedbacks",
                type: "nvarchar(750)",
                maxLength: 750,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(750)",
                oldMaxLength: 750);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "CollectionFeedbacks",
                type: "nvarchar(750)",
                maxLength: 750,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(750)",
                oldMaxLength: 750);

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

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "ExerciseFeedbacks",
                type: "nvarchar(750)",
                maxLength: 750,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(750)",
                oldMaxLength: 750,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "CollectionFeedbacks",
                type: "nvarchar(750)",
                maxLength: 750,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(750)",
                oldMaxLength: 750,
                oldNullable: true);

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
