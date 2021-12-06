using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaProject.Migrations
{
    public partial class f2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "userSurname",
                table: "AspNetUsers",
                type: "nchar(30)",
                fixedLength: true,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar",
                oldFixedLength: true);

            migrationBuilder.AlterColumn<string>(
                name: "userPassword",
                table: "AspNetUsers",
                type: "nchar(100)",
                fixedLength: true,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar",
                oldFixedLength: true,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userEmail",
                table: "AspNetUsers",
                type: "nchar(50)",
                fixedLength: true,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(450)",
                oldFixedLength: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "userSurname",
                table: "AspNetUsers",
                type: "nchar",
                fixedLength: true,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(30)",
                oldFixedLength: true,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "userPassword",
                table: "AspNetUsers",
                type: "nchar",
                fixedLength: true,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(100)",
                oldFixedLength: true,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userEmail",
                table: "AspNetUsers",
                type: "nchar(450)",
                fixedLength: true,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(50)",
                oldFixedLength: true,
                oldMaxLength: 50);
        }
    }
}
