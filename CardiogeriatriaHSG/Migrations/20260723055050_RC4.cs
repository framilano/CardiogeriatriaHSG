using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardiogeriatriaHSG.Migrations
{
    /// <inheritdoc />
    public partial class RC4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Amiodarone",
                table: "VisitTd",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Insulin",
                table: "VisitTd",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OralHypoglycemicAgents",
                table: "VisitTd",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "FirstHospitalizationDate",
                table: "VisitRc",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amiodarone",
                table: "VisitTd");

            migrationBuilder.DropColumn(
                name: "Insulin",
                table: "VisitTd");

            migrationBuilder.DropColumn(
                name: "OralHypoglycemicAgents",
                table: "VisitTd");

            migrationBuilder.DropColumn(
                name: "FirstHospitalizationDate",
                table: "VisitRc");
        }
    }
}
