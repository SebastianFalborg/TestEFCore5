using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestEFCore5.Migrations
{
    public partial class IntitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FloorRoutines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SongName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorRoutines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FloorRoutines_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GymnastGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymnastGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GymnastGroups_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FloorRoutineGymnastGroup",
                columns: table => new
                {
                    FloorRoutinesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GymnastGroupsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorRoutineGymnastGroup", x => new { x.FloorRoutinesId, x.GymnastGroupsId });
                    table.ForeignKey(
                        name: "FK_FloorRoutineGymnastGroup_FloorRoutines_FloorRoutinesId",
                        column: x => x.FloorRoutinesId,
                        principalTable: "FloorRoutines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FloorRoutineGymnastGroup_GymnastGroups_GymnastGroupsId",
                        column: x => x.GymnastGroupsId,
                        principalTable: "GymnastGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FloorRoutineGymnastGroup_GymnastGroupsId",
                table: "FloorRoutineGymnastGroup",
                column: "GymnastGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_FloorRoutines_TeamId",
                table: "FloorRoutines",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_GymnastGroups_TeamId",
                table: "GymnastGroups",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FloorRoutineGymnastGroup");

            migrationBuilder.DropTable(
                name: "FloorRoutines");

            migrationBuilder.DropTable(
                name: "GymnastGroups");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
