using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchedaVisite.Migrations
{
    /// <inheritdoc />
    public partial class APR2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Amyloidosis",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "AmyloidosisDiagnosisDate",
                table: "Visits",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AmyloidosisDmt",
                table: "Visits",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "AmyloidosisTherapyStartDate",
                table: "Visits",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AmyloidosisType",
                table: "Visits",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SevereValvularDiseaseIao",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SevereValvularDiseaseIm",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SevereValvularDiseaseSao",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SevereValvularDiseaseSm",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amyloidosis",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "AmyloidosisDiagnosisDate",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "AmyloidosisDmt",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "AmyloidosisTherapyStartDate",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "AmyloidosisType",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "SevereValvularDiseaseIao",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "SevereValvularDiseaseIm",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "SevereValvularDiseaseSao",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "SevereValvularDiseaseSm",
                table: "Visits");
        }
    }
}
