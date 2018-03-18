using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BP.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Players",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        FirstName = table.Column<string>(nullable: true),
            //        LastName = table.Column<string>(nullable: true),
            //        NickName = table.Column<string>(nullable: true),
            //        Number = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Players", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ScoringSystem",
            //    columns: table => new
            //    {
            //        Position = table.Column<int>(nullable: false),
            //        Appearance = table.Column<int>(nullable: false),
            //        Assist = table.Column<int>(nullable: false),
            //        CleanSheet = table.Column<int>(nullable: false),
            //        GoalScored = table.Column<int>(nullable: false),
            //        MOTM = table.Column<int>(nullable: false),
            //        PenMiss = table.Column<int>(nullable: false),
            //        PenSave = table.Column<int>(nullable: false),
            //        RedCard = table.Column<int>(nullable: false),
            //        YellowCard = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ScoringSystem", x => x.Position);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Teams",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Draws = table.Column<int>(nullable: false),
            //        GoalDifference = table.Column<int>(nullable: false),
            //        GoalsAgainst = table.Column<int>(nullable: false),
            //        GoalsFor = table.Column<int>(nullable: false),
            //        Losses = table.Column<int>(nullable: false),
            //        Points = table.Column<int>(nullable: false),
            //        TeamName = table.Column<string>(nullable: true),
            //        Wins = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Teams", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Matches",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        AwayScore = table.Column<int>(nullable: false),
            //        Competition = table.Column<int>(nullable: false),
            //        Date = table.Column<DateTime>(nullable: false),
            //        HomeScore = table.Column<int>(nullable: false),
            //        OpositionID = table.Column<int>(nullable: false),
            //        PlayedAtHome = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Matches", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_Matches_Teams_OpositionID",
            //            column: x => x.OpositionID,
            //            principalTable: "Teams",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Performances",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Appearance = table.Column<bool>(nullable: false),
            //        Assists = table.Column<int>(nullable: false),
            //        CleanSheet = table.Column<bool>(nullable: false),
            //        Goals = table.Column<int>(nullable: false),
            //        GoalsConceeded = table.Column<int>(nullable: false),
            //        MOTM = table.Column<bool>(nullable: false),
            //        MatchID = table.Column<int>(nullable: false),
            //        PenaltiesMissed = table.Column<int>(nullable: false),
            //        PenaltiesSaved = table.Column<int>(nullable: false),
            //        PlayerID = table.Column<int>(nullable: false),
            //        Position = table.Column<int>(nullable: false),
            //        RedCard = table.Column<bool>(nullable: false),
            //        TotalPoints = table.Column<int>(nullable: false),
            //        YellowCard = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Performances", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_Performances_Matches_MatchID",
            //            column: x => x.MatchID,
            //            principalTable: "Matches",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Performances_Players_PlayerID",
            //            column: x => x.PlayerID,
            //            principalTable: "Players",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Matches_OpositionID",
            //    table: "Matches",
            //    column: "OpositionID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Performances_MatchID",
            //    table: "Performances",
            //    column: "MatchID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Performances_PlayerID",
            //    table: "Performances",
            //    column: "PlayerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Performances");

            migrationBuilder.DropTable(
                name: "ScoringSystem");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
