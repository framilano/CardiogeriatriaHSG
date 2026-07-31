using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardiogeriatriaHSG.Migrations
{
    /// <inheritdoc />
    public partial class TFV5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TfvText",
                table: "VisitTfv",
                newName: "ThText");

            migrationBuilder.RenameColumn(
                name: "TdText",
                table: "VisitTd",
                newName: "ThText");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThText",
                table: "VisitTfv",
                newName: "TfvText");

            migrationBuilder.RenameColumn(
                name: "ThText",
                table: "VisitTd",
                newName: "TdText");
        }
    }
}
