using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchedaVisite.Migrations
{
    /// <inheritdoc />
    public partial class APR1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ArterialHypertension",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Dementia",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DementiaType",
                table: "Visits",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArterialHypertension",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Dementia",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "DementiaType",
                table: "Visits");
        }
    }
}
