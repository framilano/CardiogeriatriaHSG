using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardiogeriatriaHSG.Migrations
{
    /// <inheritdoc />
    public partial class EsamiEmatici0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VisitEe",
                columns: table => new
                {
                    VisitCode = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false),
                    Hemoglobin = table.Column<float>(type: "REAL", nullable: false),
                    Creatinine = table.Column<float>(type: "REAL", nullable: false),
                    Urea = table.Column<float>(type: "REAL", nullable: false),
                    Sodium = table.Column<float>(type: "REAL", nullable: false),
                    Potassium = table.Column<float>(type: "REAL", nullable: false),
                    NtProBnp = table.Column<float>(type: "REAL", nullable: false),
                    Bnp = table.Column<float>(type: "REAL", nullable: false),
                    Albumin = table.Column<float>(type: "REAL", nullable: false),
                    Albuminuria = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitEe", x => x.VisitCode);
                    table.ForeignKey(
                        name: "FK_VisitEe_Visits_VisitCode",
                        column: x => x.VisitCode,
                        principalTable: "Visits",
                        principalColumn: "VisitCode");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitEe");
        }
    }
}
