using System;
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
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientCode = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientCode);
                });

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

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    VisitCode = table.Column<string>(type: "TEXT", nullable: false),
                    PatientCode = table.Column<string>(type: "TEXT", nullable: false),
                    Timestamp = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    SubType = table.Column<string>(type: "TEXT", nullable: false),
                    Telemedicina = table.Column<bool>(type: "INTEGER", nullable: false),
                    AssistanceAlone = table.Column<bool>(type: "INTEGER", nullable: false),
                    AssistanceSpouse = table.Column<bool>(type: "INTEGER", nullable: false),
                    AssistanceFamilyMembers = table.Column<bool>(type: "INTEGER", nullable: false),
                    CareTaker = table.Column<bool>(type: "INTEGER", nullable: false),
                    MotorSkill = table.Column<string>(type: "TEXT", nullable: false),
                    Falls = table.Column<string>(type: "TEXT", nullable: false),
                    CognitiveDeficit = table.Column<string>(type: "TEXT", nullable: false),
                    Bpsd = table.Column<bool>(type: "INTEGER", nullable: false),
                    HearingImpairment = table.Column<bool>(type: "INTEGER", nullable: false),
                    VisualImpairment = table.Column<bool>(type: "INTEGER", nullable: false),
                    Nights = table.Column<string>(type: "TEXT", nullable: false),
                    WeightLoss = table.Column<string>(type: "TEXT", nullable: false),
                    Appetite = table.Column<string>(type: "TEXT", nullable: false),
                    Dysphagia = table.Column<string>(type: "TEXT", nullable: false),
                    NutrionalProblems = table.Column<bool>(type: "INTEGER", nullable: false),
                    Constipation = table.Column<bool>(type: "INTEGER", nullable: false),
                    Disability = table.Column<bool>(type: "INTEGER", nullable: false),
                    Amyloidosis = table.Column<bool>(type: "INTEGER", nullable: false),
                    Dementia = table.Column<bool>(type: "INTEGER", nullable: false),
                    WalkingType = table.Column<string>(type: "TEXT", nullable: true),
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
                    AmyloidosisType = table.Column<string>(type: "TEXT", nullable: true),
                    AmyloidosisDiagnosisDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    AmyloidosisDmt = table.Column<bool>(type: "INTEGER", nullable: true),
                    AmyloidosisTherapyStartDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    DementiaType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.VisitCode);
                    table.ForeignKey(
                        name: "FK_Visits_Patients_PatientCode",
                        column: x => x.PatientCode,
                        principalTable: "Patients",
                        principalColumn: "PatientCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visits_VisitsPersistedTexts_VisitCode",
                        column: x => x.VisitCode,
                        principalTable: "VisitsPersistedTexts",
                        principalColumn: "VisitCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PatientCode",
                table: "Visits",
                column: "PatientCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "VisitsPersistedTexts");
        }
    }
}
