using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardiogeriatriaHSG.Migrations
{
    /// <inheritdoc />
    public partial class Eco0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VisitEco",
                columns: table => new
                {
                    VisitCode = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false),
                    PleuralLine = table.Column<bool>(type: "INTEGER", nullable: false),
                    IrregularPleuralLine = table.Column<bool>(type: "INTEGER", nullable: false),
                    PatternA = table.Column<bool>(type: "INTEGER", nullable: false),
                    BLines = table.Column<bool>(type: "INTEGER", nullable: false),
                    CoalescentBLines = table.Column<bool>(type: "INTEGER", nullable: false),
                    GradientDistributionBLines = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConsiderationBLines = table.Column<bool>(type: "INTEGER", nullable: false),
                    RightPefs = table.Column<int>(type: "INTEGER", nullable: false),
                    LeftPefs = table.Column<int>(type: "INTEGER", nullable: false),
                    MeasurableIvc = table.Column<bool>(type: "INTEGER", nullable: false),
                    IvcDiameter = table.Column<string>(type: "TEXT", nullable: true),
                    IvcCollapsibility = table.Column<string>(type: "TEXT", nullable: true),
                    Vexus = table.Column<int>(type: "INTEGER", nullable: true),
                    PortalVeinPulsatility = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitEco", x => x.VisitCode);
                    table.ForeignKey(
                        name: "FK_VisitEco_Visits_VisitCode",
                        column: x => x.VisitCode,
                        principalTable: "Visits",
                        principalColumn: "VisitCode");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitEco");
        }
    }
}
