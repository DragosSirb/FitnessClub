using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessClub.Migrations
{
    public partial class MemberTrainerRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberTrainer",
                table: "MemberTrainer");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MemberTrainer");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MemberTrainer",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberTrainer",
                table: "MemberTrainer",
                columns: new[] { "MemberId", "TrainerId" });

            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Members_UserId' AND object_id = OBJECT_ID('Members'))
                BEGIN
                    CREATE INDEX IX_Members_UserId ON Members (UserId);
                END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberTrainer",
                table: "MemberTrainer");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MemberTrainer");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MemberTrainer",
                type: "int",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberTrainer",
                table: "MemberTrainer",
                column: "Id");

            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Members_UserId' AND object_id = OBJECT_ID('Members'))
                BEGIN
                    CREATE INDEX IX_Members_UserId ON Members (UserId);
                END
            ");
        }
    }
}
