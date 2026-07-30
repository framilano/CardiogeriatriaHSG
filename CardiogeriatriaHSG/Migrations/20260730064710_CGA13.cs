using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardiogeriatriaHSG.Migrations
{
    /// <inheritdoc />
    public partial class CGA13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cfs",
                table: "VisitCga",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "EbpmPrescriptionForThePastSixMonths",
                table: "VisitCga",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Eft",
                table: "VisitCga",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Necpal4",
                table: "VisitCga",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OtherNeurologicalDiseases",
                table: "VisitCga",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OxygenPrescriptionForThePastSixMonths",
                table: "VisitCga",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SurpriseQuestion",
                table: "VisitCga",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cfs",
                table: "VisitCga");

            migrationBuilder.DropColumn(
                name: "EbpmPrescriptionForThePastSixMonths",
                table: "VisitCga");

            migrationBuilder.DropColumn(
                name: "Eft",
                table: "VisitCga");

            migrationBuilder.DropColumn(
                name: "Necpal4",
                table: "VisitCga");

            migrationBuilder.DropColumn(
                name: "OtherNeurologicalDiseases",
                table: "VisitCga");

            migrationBuilder.DropColumn(
                name: "OxygenPrescriptionForThePastSixMonths",
                table: "VisitCga");

            migrationBuilder.DropColumn(
                name: "SurpriseQuestion",
                table: "VisitCga");
        }
    }
}
