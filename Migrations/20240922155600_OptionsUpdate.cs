using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inzynieria_oprogramowania_API.Migrations
{
    /// <inheritdoc />
    public partial class OptionsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OptionName",
                table: "Options",
                newName: "Sms");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Options",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LocationBased",
                table: "Options",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "LocationBased",
                table: "Options");

            migrationBuilder.RenameColumn(
                name: "Sms",
                table: "Options",
                newName: "OptionName");
        }
    }
}
