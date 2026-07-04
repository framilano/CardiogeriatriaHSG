using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardiogeriatriaHSG.Migrations
{
    /// <inheritdoc />
    public partial class ColumnC1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgManualText",
                table: "VisitAg",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgManualText",
                table: "VisitAg");
        }
    }
}
