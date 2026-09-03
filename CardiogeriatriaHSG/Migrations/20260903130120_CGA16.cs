using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardiogeriatriaHSG.Migrations
{
    /// <inheritdoc />
    public partial class CGA16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HeartFailureEjectionFraction",
                table: "Patients",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HeartFailureEtiologValvular",
                table: "Patients",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HeartFailureEtiologyArrhythmic",
                table: "Patients",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HeartFailureEtiologyHypertensive",
                table: "Patients",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HeartFailureEtiologyInfiltrative",
                table: "Patients",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HeartFailureEtiologyIschemic",
                table: "Patients",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HeartFailurePercentage",
                table: "Patients",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HeartFailureStadium",
                table: "Patients",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeartFailureEjectionFraction",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HeartFailureEtiologValvular",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HeartFailureEtiologyArrhythmic",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HeartFailureEtiologyHypertensive",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HeartFailureEtiologyInfiltrative",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HeartFailureEtiologyIschemic",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HeartFailurePercentage",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HeartFailureStadium",
                table: "Patients");
        }
    }
}
