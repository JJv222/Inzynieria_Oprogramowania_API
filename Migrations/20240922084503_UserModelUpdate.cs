using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inzynieria_oprogramowania_API.Migrations
{
    /// <inheritdoc />
    public partial class UserModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pins_PostTypes_PostTypeId",
                table: "Pins");

            migrationBuilder.AddColumn<int>(
                name: "Reputation",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Pins_PostTypes_PostTypeId",
                table: "Pins",
                column: "PostTypeId",
                principalTable: "PostTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pins_PostTypes_PostTypeId",
                table: "Pins");

            migrationBuilder.DropColumn(
                name: "Reputation",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Pins_PostTypes_PostTypeId",
                table: "Pins",
                column: "PostTypeId",
                principalTable: "PostTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
