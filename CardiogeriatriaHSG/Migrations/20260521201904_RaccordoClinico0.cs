using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardiogeriatriaHSG.Migrations
{
    /// <inheritdoc />
    public partial class RaccordoClinico0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VisitRc",
                columns: table => new
                {
                    VisitCode = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false),
                    Reports = table.Column<string>(type: "TEXT", nullable: false),
                    Dyspnea = table.Column<string>(type: "TEXT", nullable: false),
                    Angina = table.Column<string>(type: "TEXT", nullable: false),
                    Palpitations = table.Column<bool>(type: "INTEGER", nullable: false),
                    SleepingWithPillowsNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    SleepingSittingPosition = table.Column<bool>(type: "INTEGER", nullable: false),
                    ParoxysmalNocturnalDyspnea = table.Column<bool>(type: "INTEGER", nullable: false),
                    AcuteStressLast3Months = table.Column<bool>(type: "INTEGER", nullable: false),
                    FallsSinceLastVisit = table.Column<bool>(type: "INTEGER", nullable: false),
                    FallsSinceLastVisitNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    FallsSinceLastVisitType = table.Column<string>(type: "TEXT", nullable: true),
                    EmergenciesSinceLastVisit = table.Column<bool>(type: "INTEGER", nullable: false),
                    EmergenciesSinceLastVisitNumber = table.Column<bool>(type: "INTEGER", nullable: true),
                    EmergenciesSinceLastVisitCause = table.Column<string>(type: "TEXT", nullable: true),
                    HospitalizationsSinceLastVisit = table.Column<bool>(type: "INTEGER", nullable: false),
                    HospitalizationsSinceLastVisitNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    HospitalizationsSinceLastVisitDays = table.Column<int>(type: "INTEGER", nullable: true),
                    HospitalizationsSinceLastVisitCause = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitRc", x => x.VisitCode);
                    table.ForeignKey(
                        name: "FK_VisitRc_Visits_VisitCode",
                        column: x => x.VisitCode,
                        principalTable: "Visits",
                        principalColumn: "VisitCode");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitRc");
        }
    }
}
