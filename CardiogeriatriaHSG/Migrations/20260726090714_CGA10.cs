using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardiogeriatriaHSG.Migrations
{
    /// <inheritdoc />
    public partial class CGA10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "SppbFourMetersTime",
                table: "VisitCga",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SppbFourMetersTime",
                table: "VisitCga",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(float),
                oldType: "REAL",
                oldNullable: true);
        }
    }
}
