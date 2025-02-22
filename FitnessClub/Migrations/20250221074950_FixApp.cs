using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessClub.Migrations
{
    /// <inheritdoc />
    public partial class FixApp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "Sessions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainersId",
                table: "Sessions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_TrainersId",
                table: "Sessions",
                column: "TrainersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Trainers_TrainersId",
                table: "Sessions",
                column: "TrainersId",
                principalTable: "Trainers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Trainers_TrainersId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_TrainersId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "TrainersId",
                table: "Sessions");
        }
    }
}
