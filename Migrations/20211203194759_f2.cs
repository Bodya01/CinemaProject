using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaProject.Migrations
{
    public partial class f2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userPhone",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "userName",
                table: "AspNetUsers",
                newName: "UserName");

            migrationBuilder.AlterColumn<string>(
                name: "userPassword",
                table: "AspNetUsers",
                type: "nchar(100)",
                fixedLength: true,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(1000)",
                oldFixedLength: true,
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nchar(256)",
                fixedLength: true,
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(256)",
                oldFixedLength: true,
                oldMaxLength: 256);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "AspNetUsers",
                newName: "userName");

            migrationBuilder.AlterColumn<string>(
                name: "userPassword",
                table: "AspNetUsers",
                type: "nchar(1000)",
                fixedLength: true,
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nchar(100)",
                oldFixedLength: true,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userName",
                table: "AspNetUsers",
                type: "nchar(256)",
                fixedLength: true,
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nchar(256)",
                oldFixedLength: true,
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userPhone",
                table: "AspNetUsers",
                type: "nchar(30)",
                fixedLength: true,
                maxLength: 30,
                nullable: true);
        }
    }
}
