using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inzynieria_oprogramowania_API.Migrations
{
    /// <inheritdoc />
    public partial class FixNamingInVOTES : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Pins_PinId",
                table: "Votes");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Users_UserId",
                table: "Votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Votes",
                table: "Votes");

            migrationBuilder.RenameTable(
                name: "Votes",
                newName: "VotesPost");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_UserId",
                table: "VotesPost",
                newName: "IX_VotesPost_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_PinId",
                table: "VotesPost",
                newName: "IX_VotesPost_PinId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VotesPost",
                table: "VotesPost",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VotesPost_Pins_PinId",
                table: "VotesPost",
                column: "PinId",
                principalTable: "Pins",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VotesPost_Users_UserId",
                table: "VotesPost",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VotesPost_Pins_PinId",
                table: "VotesPost");

            migrationBuilder.DropForeignKey(
                name: "FK_VotesPost_Users_UserId",
                table: "VotesPost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VotesPost",
                table: "VotesPost");

            migrationBuilder.RenameTable(
                name: "VotesPost",
                newName: "Votes");

            migrationBuilder.RenameIndex(
                name: "IX_VotesPost_UserId",
                table: "Votes",
                newName: "IX_Votes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_VotesPost_PinId",
                table: "Votes",
                newName: "IX_Votes_PinId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Votes",
                table: "Votes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Pins_PinId",
                table: "Votes",
                column: "PinId",
                principalTable: "Pins",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Users_UserId",
                table: "Votes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
