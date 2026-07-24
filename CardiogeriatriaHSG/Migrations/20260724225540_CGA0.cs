using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardiogeriatriaHSG.Migrations
{
    /// <inheritdoc />
    public partial class CGA0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VisitCga",
                columns: table => new
                {
                    VisitCode = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false),
                    CgaManualText = table.Column<string>(type: "TEXT", nullable: true),
                    Diet = table.Column<bool>(type: "INTEGER", nullable: false),
                    Continence = table.Column<bool>(type: "INTEGER", nullable: false),
                    Dressing = table.Column<bool>(type: "INTEGER", nullable: false),
                    Shower = table.Column<bool>(type: "INTEGER", nullable: false),
                    PosturalPassages = table.Column<bool>(type: "INTEGER", nullable: true),
                    Hygiene = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitCga", x => x.VisitCode);
                    table.ForeignKey(
                        name: "FK_VisitCga_Visits_VisitCode",
                        column: x => x.VisitCode,
                        principalTable: "Visits",
                        principalColumn: "VisitCode");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitCga");
        }
    }
}
