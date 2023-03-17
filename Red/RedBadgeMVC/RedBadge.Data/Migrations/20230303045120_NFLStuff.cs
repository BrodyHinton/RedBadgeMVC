using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RedBadge.Data.Migrations
{
    /// <inheritdoc />
    public partial class NFLStuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MVP",
                table: "Games");

            migrationBuilder.InsertData(
                table: "AwayTeams",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Philadelphia Eagles" });

            migrationBuilder.InsertData(
                table: "HomeTeams",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Kansas City Chiefs" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Championships", "Fans", "LeagueId", "Loses", "Name", "Wins" },
                values: new object[,]
                {
                    { 1, 2, null, 1, 13, "Arizona Cardinals", 4 },
                    { 2, 0, null, 1, 10, "Atlanta Falcons", 7 },
                    { 3, 2, null, 1, 7, "Baltimore Ravens", 10 },
                    { 4, 2, null, 1, 3, "Buffalo Bills", 13 },
                    { 5, 0, null, 1, 10, "Carolina Panthers", 7 },
                    { 6, 9, null, 1, 14, "Chicago Bears", 3 },
                    { 7, 0, null, 1, 4, "Cincinnati Bengals", 12 },
                    { 8, 8, null, 1, 10, "Cleveland Browns", 7 },
                    { 9, 5, null, 1, 5, "Dallas Cowboys", 12 },
                    { 10, 3, null, 1, 12, "Denver Broncos", 5 },
                    { 11, 4, null, 1, 8, "Detroit Lions", 9 },
                    { 12, 13, null, 1, 9, "Green Bay Packers", 8 },
                    { 13, 0, null, 1, 13, "Houston Texans", 3 },
                    { 14, 4, null, 1, 12, "Indianapolis Colts", 4 },
                    { 15, 0, null, 1, 8, "Jacksonville Jaguars", 9 },
                    { 16, 4, null, 1, 3, "Kansas City Chiefs", 14 },
                    { 17, 3, null, 1, 11, "Las Vegas Raiders", 6 },
                    { 18, 1, null, 1, 7, "Los Angeles Chargers", 10 },
                    { 19, 4, null, 1, 12, "Los Angeles Rams", 5 },
                    { 20, 2, null, 1, 8, "Miami Dolphins", 9 },
                    { 21, 0, null, 1, 4, "Minnesota Vikings", 13 },
                    { 22, 6, null, 1, 9, "New England Patriots", 8 },
                    { 23, 1, null, 1, 10, "New Orleans Saints", 7 },
                    { 24, 8, null, 1, 7, "New York Giants", 9 },
                    { 25, 1, null, 1, 10, "New York Jets", 7 },
                    { 26, 4, null, 1, 3, "Philadelphia Eagles", 14 },
                    { 27, 6, null, 1, 8, "Pittsburgh Steelers", 9 },
                    { 28, 5, null, 1, 4, "San Francisco 49ers", 13 },
                    { 29, 1, null, 1, 8, "Seattle Seahawks", 9 },
                    { 30, 2, null, 1, 9, "Tampa Bay Buccaneers", 8 },
                    { 31, 2, null, 1, 10, "Tennessee Titans", 7 },
                    { 32, 5, null, 1, 8, "Washington Commanders", 8 }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "AwayTeamId", "AwayTeamScore", "AwayTeamVotes", "Date", "HighlightLink", "HomeTeamId", "HomeTeamScore", "HomeTeamVotes", "LeagueName" },
                values: new object[] { 1, 1, 35, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.youtube.com/watch?v=BWkt79xkd00&ab_channel=NFL", 1, 38, null, "NFL" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Championships", "Fans", "Name", "TeamId" },
                values: new object[,]
                {
                    { 1, 2, null, "Patrick Mahomes", 16 },
                    { 2, 0, null, "Justin Jefferson", 21 },
                    { 3, 0, null, "Joe Burrow", 7 },
                    { 4, 0, null, "Josh Allen", 4 },
                    { 5, 0, null, "Jalen Hurts", 26 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "AwayTeams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HomeTeams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.AddColumn<string>(
                name: "MVP",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
