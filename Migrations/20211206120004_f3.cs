using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaProject.Migrations
{
    public partial class f3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MoviePhotoPath",
                table: "Movie",
                newName: "moviePhotoPath");

            migrationBuilder.AddColumn<string>(
                name: "moviePreviewPath",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "movieTrailerPath",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "moviePreviewPath",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "movieTrailerPath",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "moviePhotoPath",
                table: "Movie",
                newName: "MoviePhotoPath");
        }
    }
}
