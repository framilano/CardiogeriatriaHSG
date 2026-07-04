using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardiogeriatriaHSG.Migrations
{
    /// <inheritdoc />
    public partial class ColumnC0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PatientManualText",
                table: "Patients",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientManualText",
                table: "Patients");
        }
    }
}
