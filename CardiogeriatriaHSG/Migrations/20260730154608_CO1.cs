using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardiogeriatriaHSG.Migrations
{
    /// <inheritdoc />
    public partial class CO1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VisitCo",
                columns: table => new
                {
                    VisitCode = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false),
                    CoText = table.Column<string>(type: "TEXT", maxLength: 3000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitCo", x => x.VisitCode);
                    table.ForeignKey(
                        name: "FK_VisitCo_Visits_VisitCode",
                        column: x => x.VisitCode,
                        principalTable: "Visits",
                        principalColumn: "VisitCode");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitCo");
        }
    }
}
