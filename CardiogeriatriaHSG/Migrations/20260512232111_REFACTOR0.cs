using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardiogeriatriaHSG.Migrations
{
    /// <inheritdoc />
    public partial class REFACTOR0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_VisitsPersistedTexts_VisitCode",
                table: "Visits");

            migrationBuilder.DropTable(
                name: "VisitsPersistedTexts");

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
                name: "Anemia",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Appetite",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "ArterialHypertension",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "AssistanceAlone",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "AssistanceFamilyMembers",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "AssistanceSpouse",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "AtrialFibrillation",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Bpsd",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Bradycardia",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "CareTaker",
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
                name: "CognitiveDeficit",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Constipation",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Dementia",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "DementiaType",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Diabetes",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Disability",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Dysphagia",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Falls",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "HearingImpairment",
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
                name: "MotorSkill",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Neoplasm",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "NeuromuscularDisorders",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Nights",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "NutrionalProblems",
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

            migrationBuilder.DropColumn(
                name: "SevereValvularDiseaseIao",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "SevereValvularDiseaseIm",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "SevereValvularDiseaseItr",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "SevereValvularDiseaseSao",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "SevereValvularDiseaseSm",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "VisualImpairment",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "WalkingType",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "WeightLoss",
                table: "Visits");

            migrationBuilder.CreateTable(
                name: "VisitAg",
                columns: table => new
                {
                    VisitCode = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false),
                    AssistanceAlone = table.Column<bool>(type: "INTEGER", nullable: false),
                    AssistanceSpouse = table.Column<bool>(type: "INTEGER", nullable: false),
                    AssistanceFamilyMembers = table.Column<bool>(type: "INTEGER", nullable: false),
                    CareTaker = table.Column<bool>(type: "INTEGER", nullable: false),
                    MotorSkill = table.Column<string>(type: "TEXT", nullable: true),
                    WalkingType = table.Column<string>(type: "TEXT", nullable: true),
                    Falls = table.Column<string>(type: "TEXT", nullable: true),
                    CognitiveDeficit = table.Column<string>(type: "TEXT", nullable: true),
                    Bpsd = table.Column<bool>(type: "INTEGER", nullable: false),
                    HearingImpairment = table.Column<bool>(type: "INTEGER", nullable: false),
                    VisualImpairment = table.Column<bool>(type: "INTEGER", nullable: false),
                    Nights = table.Column<string>(type: "TEXT", nullable: true),
                    WeightLoss = table.Column<string>(type: "TEXT", nullable: true),
                    Appetite = table.Column<string>(type: "TEXT", nullable: true),
                    Dysphagia = table.Column<string>(type: "TEXT", nullable: true),
                    NutrionalProblems = table.Column<bool>(type: "INTEGER", nullable: false),
                    Constipation = table.Column<bool>(type: "INTEGER", nullable: false),
                    Disability = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitAg", x => x.VisitCode);
                });

            migrationBuilder.CreateTable(
                name: "VisitApr",
                columns: table => new
                {
                    VisitCode = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false),
                    AprText = table.Column<string>(type: "TEXT", nullable: true),
                    IschemicHeartDisease = table.Column<bool>(type: "INTEGER", nullable: false),
                    HeartFailure = table.Column<bool>(type: "INTEGER", nullable: false),
                    AtrialFibrillation = table.Column<bool>(type: "INTEGER", nullable: false),
                    CerebrovascularDisease = table.Column<bool>(type: "INTEGER", nullable: false),
                    Neoplasm = table.Column<bool>(type: "INTEGER", nullable: false),
                    ChronicObstructivePulmonaryDisease = table.Column<bool>(type: "INTEGER", nullable: false),
                    ChronicKidneyDisease = table.Column<bool>(type: "INTEGER", nullable: false),
                    PeripheralVascularDisease = table.Column<bool>(type: "INTEGER", nullable: false),
                    Diabetes = table.Column<bool>(type: "INTEGER", nullable: false),
                    ChronicSkinUlcers = table.Column<bool>(type: "INTEGER", nullable: false),
                    Parkinson = table.Column<bool>(type: "INTEGER", nullable: false),
                    Schizophrenia = table.Column<bool>(type: "INTEGER", nullable: false),
                    NeuromuscularDisorders = table.Column<bool>(type: "INTEGER", nullable: false),
                    HipFracture = table.Column<bool>(type: "INTEGER", nullable: false),
                    Anemia = table.Column<bool>(type: "INTEGER", nullable: false),
                    OxygenTherapyLast6Months = table.Column<bool>(type: "INTEGER", nullable: false),
                    HospitalizationLast6Months = table.Column<bool>(type: "INTEGER", nullable: false),
                    HeparinUseLast6Months = table.Column<bool>(type: "INTEGER", nullable: false),
                    Bradycardia = table.Column<bool>(type: "INTEGER", nullable: false),
                    ArterialHypertension = table.Column<bool>(type: "INTEGER", nullable: false),
                    SevereValvularDiseaseSm = table.Column<bool>(type: "INTEGER", nullable: false),
                    SevereValvularDiseaseIm = table.Column<bool>(type: "INTEGER", nullable: false),
                    SevereValvularDiseaseIao = table.Column<bool>(type: "INTEGER", nullable: false),
                    SevereValvularDiseaseSao = table.Column<bool>(type: "INTEGER", nullable: false),
                    SevereValvularDiseaseItr = table.Column<bool>(type: "INTEGER", nullable: false),
                    Amyloidosis = table.Column<bool>(type: "INTEGER", nullable: false),
                    AmyloidosisType = table.Column<string>(type: "TEXT", nullable: true),
                    AmyloidosisDiagnosisDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    AmyloidosisDmt = table.Column<bool>(type: "INTEGER", nullable: true),
                    AmyloidosisTherapyStartDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    Dementia = table.Column<bool>(type: "INTEGER", nullable: false),
                    DementiaType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitApr", x => x.VisitCode);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_VisitAg_VisitCode",
                table: "Visits",
                column: "VisitCode",
                principalTable: "VisitAg",
                principalColumn: "VisitCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_VisitApr_VisitCode",
                table: "Visits",
                column: "VisitCode",
                principalTable: "VisitApr",
                principalColumn: "VisitCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_VisitAg_VisitCode",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_VisitApr_VisitCode",
                table: "Visits");

            migrationBuilder.DropTable(
                name: "VisitAg");

            migrationBuilder.DropTable(
                name: "VisitApr");

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
                name: "Anemia",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Appetite",
                table: "Visits",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ArterialHypertension",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AssistanceAlone",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AssistanceFamilyMembers",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AssistanceSpouse",
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
                name: "Bpsd",
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
                name: "CareTaker",
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

            migrationBuilder.AddColumn<string>(
                name: "CognitiveDeficit",
                table: "Visits",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Constipation",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Dementia",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DementiaType",
                table: "Visits",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Diabetes",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Disability",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Dysphagia",
                table: "Visits",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Falls",
                table: "Visits",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HearingImpairment",
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

            migrationBuilder.AddColumn<string>(
                name: "MotorSkill",
                table: "Visits",
                type: "TEXT",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "Nights",
                table: "Visits",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NutrionalProblems",
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
                name: "SevereValvularDiseaseItr",
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

            migrationBuilder.AddColumn<bool>(
                name: "VisualImpairment",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "WalkingType",
                table: "Visits",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WeightLoss",
                table: "Visits",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VisitsPersistedTexts",
                columns: table => new
                {
                    VisitCode = table.Column<string>(type: "TEXT", nullable: false),
                    AprText = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitsPersistedTexts", x => x.VisitCode);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_VisitsPersistedTexts_VisitCode",
                table: "Visits",
                column: "VisitCode",
                principalTable: "VisitsPersistedTexts",
                principalColumn: "VisitCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
