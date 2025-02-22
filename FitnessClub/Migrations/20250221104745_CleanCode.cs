using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessClub.Migrations
{
    /// <inheritdoc />
    public partial class CleanCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recommendations_Members_MemberId",
                table: "Recommendations");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "Recommendations",
                newName: "MembersId");

            migrationBuilder.RenameIndex(
                name: "IX_Recommendations_MemberId",
                table: "Recommendations",
                newName: "IX_Recommendations_MembersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendations_Members_MembersId",
                table: "Recommendations",
                column: "MembersId",
                principalTable: "Members",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recommendations_Members_MembersId",
                table: "Recommendations");

            migrationBuilder.RenameColumn(
                name: "MembersId",
                table: "Recommendations",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Recommendations_MembersId",
                table: "Recommendations",
                newName: "IX_Recommendations_MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendations_Members_MemberId",
                table: "Recommendations",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");
        }
    }
}
