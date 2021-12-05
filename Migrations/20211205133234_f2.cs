using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaProject.Migrations
{
    public partial class f2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_User",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieRating_User",
                table: "MovieRating");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AspNetUsers_userId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_User",
                table: "Cart",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieRating_User",
                table: "MovieRating",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_User",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieRating_User",
                table: "MovieRating");

            migrationBuilder.AddColumn<long>(
                name: "userId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AspNetUsers_userId",
                table: "AspNetUsers",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_User",
                table: "Cart",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieRating_User",
                table: "MovieRating",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
