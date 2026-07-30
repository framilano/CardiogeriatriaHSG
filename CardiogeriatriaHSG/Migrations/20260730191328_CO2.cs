using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardiogeriatriaHSG.Migrations
{
    /// <inheritdoc />
    public partial class CO2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EbpmPrescriptionForThePastSixMonths",
                table: "VisitCga");

            migrationBuilder.DropColumn(
                name: "OxygenPrescriptionForThePastSixMonths",
                table: "VisitCga");

            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "VisitCga",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Height",
                table: "VisitCga",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(float),
                oldType: "REAL",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "VisitCga",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<float>(
                name: "Height",
                table: "VisitCga",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddColumn<bool>(
                name: "EbpmPrescriptionForThePastSixMonths",
                table: "VisitCga",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OxygenPrescriptionForThePastSixMonths",
                table: "VisitCga",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
