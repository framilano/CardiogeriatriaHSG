using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardiogeriatriaHSG.Migrations
{
    /// <inheritdoc />
    public partial class ColumnC2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RcManualText",
                table: "VisitRc",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EoManualText",
                table: "VisitEo",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EeManualText",
                table: "VisitEe",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RcManualText",
                table: "VisitRc");

            migrationBuilder.DropColumn(
                name: "EoManualText",
                table: "VisitEo");

            migrationBuilder.DropColumn(
                name: "EeManualText",
                table: "VisitEe");
        }
    }
}
