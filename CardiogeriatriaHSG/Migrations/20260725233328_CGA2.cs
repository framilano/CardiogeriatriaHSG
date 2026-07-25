using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardiogeriatriaHSG.Migrations
{
    /// <inheritdoc />
    public partial class CGA2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Car",
                table: "VisitCga",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Cooking",
                table: "VisitCga",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HouseholdChores",
                table: "VisitCga",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Laundry",
                table: "VisitCga",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Medicines",
                table: "VisitCga",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Phone",
                table: "VisitCga",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SenseOfMoney",
                table: "VisitCga",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Shopping",
                table: "VisitCga",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Car",
                table: "VisitCga");

            migrationBuilder.DropColumn(
                name: "Cooking",
                table: "VisitCga");

            migrationBuilder.DropColumn(
                name: "HouseholdChores",
                table: "VisitCga");

            migrationBuilder.DropColumn(
                name: "Laundry",
                table: "VisitCga");

            migrationBuilder.DropColumn(
                name: "Medicines",
                table: "VisitCga");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "VisitCga");

            migrationBuilder.DropColumn(
                name: "SenseOfMoney",
                table: "VisitCga");

            migrationBuilder.DropColumn(
                name: "Shopping",
                table: "VisitCga");
        }
    }
}
