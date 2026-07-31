using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardiogeriatriaHSG.Migrations
{
    /// <inheritdoc />
    public partial class TFV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VisitTfv",
                columns: table => new
                {
                    VisitCode = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false),
                    TfvText = table.Column<string>(type: "TEXT", nullable: true),
                    ProteinSupplementation = table.Column<bool>(type: "INTEGER", nullable: false),
                    PhysicalExercise = table.Column<bool>(type: "INTEGER", nullable: false),
                    Furosemide = table.Column<bool>(type: "INTEGER", nullable: false),
                    FurosemideDose = table.Column<int>(type: "INTEGER", nullable: true),
                    BetaBlocker = table.Column<bool>(type: "INTEGER", nullable: false),
                    Mra = table.Column<bool>(type: "INTEGER", nullable: false),
                    AceInhibitor = table.Column<bool>(type: "INTEGER", nullable: false),
                    Arb = table.Column<bool>(type: "INTEGER", nullable: false),
                    Sglt2Inhibitor = table.Column<bool>(type: "INTEGER", nullable: false),
                    Arni = table.Column<bool>(type: "INTEGER", nullable: false),
                    Vericiguat = table.Column<bool>(type: "INTEGER", nullable: false),
                    OtherLoopDiuretic = table.Column<bool>(type: "INTEGER", nullable: false),
                    Amiodarone = table.Column<bool>(type: "INTEGER", nullable: false),
                    Doac = table.Column<bool>(type: "INTEGER", nullable: false),
                    Vka = table.Column<bool>(type: "INTEGER", nullable: false),
                    Acetazolamide = table.Column<bool>(type: "INTEGER", nullable: false),
                    Hydrochlorothiazide = table.Column<bool>(type: "INTEGER", nullable: false),
                    Acoramidis = table.Column<bool>(type: "INTEGER", nullable: false),
                    Tafamidis = table.Column<bool>(type: "INTEGER", nullable: false),
                    Vutrisiran = table.Column<bool>(type: "INTEGER", nullable: false),
                    CalciumChannelBlockers = table.Column<bool>(type: "INTEGER", nullable: false),
                    Ranolazine = table.Column<bool>(type: "INTEGER", nullable: false),
                    Nitrates = table.Column<bool>(type: "INTEGER", nullable: false),
                    Glp1 = table.Column<bool>(type: "INTEGER", nullable: false),
                    Doxazosin = table.Column<bool>(type: "INTEGER", nullable: false),
                    Clonidine = table.Column<bool>(type: "INTEGER", nullable: false),
                    Fibrates = table.Column<bool>(type: "INTEGER", nullable: false),
                    Statins = table.Column<bool>(type: "INTEGER", nullable: false),
                    Ezetimibe = table.Column<bool>(type: "INTEGER", nullable: false),
                    OralHypoglycemicAgents = table.Column<bool>(type: "INTEGER", nullable: false),
                    Dpp4 = table.Column<bool>(type: "INTEGER", nullable: false),
                    Insulin = table.Column<bool>(type: "INTEGER", nullable: false),
                    Ppi = table.Column<bool>(type: "INTEGER", nullable: false),
                    AcheInhibitorOrMemantine = table.Column<bool>(type: "INTEGER", nullable: false),
                    Benzodiazepines = table.Column<bool>(type: "INTEGER", nullable: false),
                    ZDrugs = table.Column<bool>(type: "INTEGER", nullable: false),
                    LowDoseTrazodone = table.Column<bool>(type: "INTEGER", nullable: false),
                    Antidepressants = table.Column<bool>(type: "INTEGER", nullable: false),
                    Antipsychotics = table.Column<bool>(type: "INTEGER", nullable: false),
                    Paracetamol = table.Column<bool>(type: "INTEGER", nullable: false),
                    Opioids = table.Column<bool>(type: "INTEGER", nullable: false),
                    OtherAnalgesics = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitTfv", x => x.VisitCode);
                    table.ForeignKey(
                        name: "FK_VisitTfv_Visits_VisitCode",
                        column: x => x.VisitCode,
                        principalTable: "Visits",
                        principalColumn: "VisitCode");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitTfv");
        }
    }
}
