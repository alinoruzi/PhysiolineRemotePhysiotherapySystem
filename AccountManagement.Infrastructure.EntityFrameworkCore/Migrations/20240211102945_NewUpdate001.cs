using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountManagement.Infrastructure.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdate001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Identifier",
                schema: "AM",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Identifier",
                schema: "AM",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "AM",
                table: "Users",
                newName: "IsRegistered");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "AM",
                table: "Users",
                type: "nvarchar(2500)",
                maxLength: 2500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1500)",
                oldMaxLength: 1500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Biography",
                schema: "AM",
                table: "Experts",
                type: "nvarchar(750)",
                maxLength: 750,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Biography",
                schema: "AM",
                table: "Experts");

            migrationBuilder.RenameColumn(
                name: "IsRegistered",
                schema: "AM",
                table: "Users",
                newName: "IsActive");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "AM",
                table: "Users",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2500)",
                oldMaxLength: 2500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Identifier",
                schema: "AM",
                table: "Users",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Identifier",
                schema: "AM",
                table: "Users",
                column: "Identifier",
                unique: true,
                filter: "[Identifier] IS NOT NULL");
        }
    }
}
