using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardiogeriatriaHSG.Migrations
{
    /// <inheritdoc />
    public partial class EsamiObiettivo1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VisitEo",
                columns: table => new
                {
                    VisitCode = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false),
                    MinimumBloodPressure = table.Column<int>(type: "INTEGER", nullable: true),
                    MaximumBloodPressure = table.Column<int>(type: "INTEGER", nullable: true),
                    HeartRate = table.Column<int>(type: "INTEGER", nullable: true),
                    JugularVenousDistension = table.Column<bool>(type: "INTEGER", nullable: false),
                    Rheoencephalography = table.Column<bool>(type: "INTEGER", nullable: false),
                    HeartSoundType = table.Column<string>(type: "TEXT", nullable: true),
                    HeartSoundRhythm = table.Column<string>(type: "TEXT", nullable: true),
                    HeartSoundPauses = table.Column<string>(type: "TEXT", nullable: true),
                    ChestMv = table.Column<string>(type: "TEXT", nullable: true),
                    ChestNoises = table.Column<string>(type: "TEXT", nullable: true),
                    DependentEdema = table.Column<bool>(type: "INTEGER", nullable: false),
                    PeripheralNeuropathy = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrthostaticHypotension = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitEo", x => x.VisitCode);
                    table.ForeignKey(
                        name: "FK_VisitEo_Visits_VisitCode",
                        column: x => x.VisitCode,
                        principalTable: "Visits",
                        principalColumn: "VisitCode");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitEo");
        }
    }
}
