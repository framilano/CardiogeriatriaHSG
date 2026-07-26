using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardiogeriatriaHSG.Migrations
{
    /// <inheritdoc />
    public partial class CGA5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Handgrip",
                table: "VisitCga",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "VisitCga",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "VisitCga",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Handgrip",
                table: "VisitCga");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "VisitCga");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "VisitCga");
        }
    }
}
