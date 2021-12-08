using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaProject.Migrations
{
    public partial class f3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "nameMovie",
                table: "Movie",
                type: "nchar(50)",
                fixedLength: true,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar",
                oldFixedLength: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "nameMovie",
                table: "Movie",
                type: "nchar",
                fixedLength: true,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(50)",
                oldFixedLength: true,
                oldMaxLength: 50);
        }
    }
}
