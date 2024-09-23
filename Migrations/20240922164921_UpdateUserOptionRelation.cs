using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inzynieria_oprogramowania_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserOptionRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Options_OptionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_OptionId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OptionId",
                table: "Users",
                column: "OptionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Options_OptionId",
                table: "Users",
                column: "OptionId",
                principalTable: "Options",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Options_OptionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_OptionId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OptionId",
                table: "Users",
                column: "OptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Options_OptionId",
                table: "Users",
                column: "OptionId",
                principalTable: "Options",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
