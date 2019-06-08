using Microsoft.EntityFrameworkCore.Migrations;

namespace CTUPAD.Web.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "ContestantJugemnents",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "ContestantJugemnents",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
