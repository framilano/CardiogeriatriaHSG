using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardiogeriatriaHSG.Migrations
{
    /// <inheritdoc />
    public partial class EsamiObiettivo4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DependentEdemaFovea",
                table: "VisitEo",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DependentEdemaLocation",
                table: "VisitEo",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DependentEdemaType",
                table: "VisitEo",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DependentEdemaFovea",
                table: "VisitEo");

            migrationBuilder.DropColumn(
                name: "DependentEdemaLocation",
                table: "VisitEo");

            migrationBuilder.DropColumn(
                name: "DependentEdemaType",
                table: "VisitEo");
        }
    }
}
