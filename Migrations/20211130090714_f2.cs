﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaProject.Migrations
{
    public partial class f2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_User_userEmail",
                table: "User",
                column: "userEmail",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_userEmail",
                table: "User");
        }
    }
}
