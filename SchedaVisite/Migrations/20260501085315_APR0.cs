using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchedaVisite.Migrations
{
    /// <inheritdoc />
    public partial class APR0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Anemia",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AtrialFibrillation",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Bradycardia",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CerebrovascularDisease",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ChronicKidneyDisease",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ChronicObstructivePulmonaryDisease",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ChronicSkinUlcers",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Diabetes",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HeartFailure",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HeparinUseLast6Months",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HipFracture",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HospitalizationLast6Months",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IschemicHeartDisease",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Neoplasm",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NeuromuscularDisorders",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OxygenTherapyLast6Months",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Parkinson",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PeripheralVascularDisease",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Schizophrenia",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anemia",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "AtrialFibrillation",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Bradycardia",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "CerebrovascularDisease",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "ChronicKidneyDisease",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "ChronicObstructivePulmonaryDisease",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "ChronicSkinUlcers",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Diabetes",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "HeartFailure",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "HeparinUseLast6Months",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "HipFracture",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "HospitalizationLast6Months",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "IschemicHeartDisease",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Neoplasm",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "NeuromuscularDisorders",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "OxygenTherapyLast6Months",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Parkinson",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "PeripheralVascularDisease",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Schizophrenia",
                table: "Visits");
        }
    }
}
