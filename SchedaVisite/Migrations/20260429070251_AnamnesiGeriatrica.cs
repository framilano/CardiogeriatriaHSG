using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchedaVisite.Migrations
{
    /// <inheritdoc />
    public partial class AnamnesiGeriatrica : Migration
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
                    WalkingType = table.Column<string>(type: "TEXT", nullable: true),
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
                    Disability = table.Column<bool>(type: "INTEGER", nullable: false)
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
        }
    }
}
