using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardiogeriatriaHSG.Migrations
{
    /// <inheritdoc />
    public partial class CGA3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BorgPostSppb",
                table: "VisitCga",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Es",
                table: "VisitCga",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Kccq",
                table: "VisitCga",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Mmse",
                table: "VisitCga",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Moca",
                table: "VisitCga",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestingBorg",
                table: "VisitCga",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SppbBalance",
                table: "VisitCga",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SppbFourMetersTime",
                table: "VisitCga",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SppbSitToStand",
                table: "VisitCga",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BorgPostSppb",
                table: "VisitCga");

            migrationBuilder.DropColumn(
                name: "Es",
                table: "VisitCga");

            migrationBuilder.DropColumn(
                name: "Kccq",
                table: "VisitCga");

            migrationBuilder.DropColumn(
                name: "Mmse",
                table: "VisitCga");

            migrationBuilder.DropColumn(
                name: "Moca",
                table: "VisitCga");

            migrationBuilder.DropColumn(
                name: "RestingBorg",
                table: "VisitCga");

            migrationBuilder.DropColumn(
                name: "SppbBalance",
                table: "VisitCga");

            migrationBuilder.DropColumn(
                name: "SppbFourMetersTime",
                table: "VisitCga");

            migrationBuilder.DropColumn(
                name: "SppbSitToStand",
                table: "VisitCga");
        }
    }
}
