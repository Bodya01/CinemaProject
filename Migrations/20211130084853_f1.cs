﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaProject.Migrations
{
    public partial class f1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    categoryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    categoryDescription = table.Column<string>(type: "char(100)", unicode: false, fixedLength: true, maxLength: 100, nullable: false),
                    createAt = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.categoryId);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    cityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cityName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.cityId);
                });

            migrationBuilder.CreateTable(
                name: "Demonstration",
                columns: table => new
                {
                    demonstrationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    demonstrationName = table.Column<string>(type: "char(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: false),
                    cof = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demonstration", x => x.demonstrationId);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    movieId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameMovie = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false),
                    ageRestriction = table.Column<int>(type: "int", nullable: false),
                    movieDescription = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    createAt = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.movieId);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    permissionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    permissionName = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: false),
                    permissionDescription = table.Column<string>(type: "nchar(40)", fixedLength: true, maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.permissionId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    productId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    productPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.productId);
                });

            migrationBuilder.CreateTable(
                name: "Promocode",
                columns: table => new
                {
                    promocodeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    promocodeName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    promocodeDescription = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    countUse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocode", x => x.promocodeId);
                });

            migrationBuilder.CreateTable(
                name: "Reciept",
                columns: table => new
                {
                    recieptId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    totalPrice = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    paymentType = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reciept", x => x.recieptId);
                });

            migrationBuilder.CreateTable(
                name: "reservedTicket",
                columns: table => new
                {
                    reservedTicketId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservedTicket", x => x.reservedTicketId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    roleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleName = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: false),
                    roleDescription = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.roleId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false),
                    userSurname = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: false),
                    userEmail = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    userPassword = table.Column<string>(type: "nchar(1000)", fixedLength: true, maxLength: 1000, nullable: false),
                    userPhone = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "Subcategory",
                columns: table => new
                {
                    subcategoryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subcategoryName = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    subcategoryDescription = table.Column<string>(type: "char(100)", unicode: false, fixedLength: true, maxLength: 100, nullable: false),
                    categoryId = table.Column<long>(type: "bigint", nullable: false),
                    createAt = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategory", x => x.subcategoryId);
                    table.ForeignKey(
                        name: "FK_Subcategory_Category",
                        column: x => x.categoryId,
                        principalTable: "Category",
                        principalColumn: "categoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cinema",
                columns: table => new
                {
                    cinemaId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adrees = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    cityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinema", x => x.cinemaId);
                    table.ForeignKey(
                        name: "FK_Cinema_City",
                        column: x => x.cityId,
                        principalTable: "City",
                        principalColumn: "cityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    district = table.Column<string>(type: "char(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: false),
                    st = table.Column<string>(type: "char(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: false),
                    cityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Location_City",
                        column: x => x.cityId,
                        principalTable: "City",
                        principalColumn: "cityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    rolePermissionsId = table.Column<long>(type: "bigint", nullable: false),
                    roleId = table.Column<long>(type: "bigint", nullable: false),
                    permissionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rolePermissions", x => new { x.rolePermissionsId, x.roleId, x.permissionId });
                    table.ForeignKey(
                        name: "FK_rolePermissions_Permission",
                        column: x => x.permissionId,
                        principalTable: "Permission",
                        principalColumn: "permissionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rolePermissions_Role",
                        column: x => x.roleId,
                        principalTable: "Role",
                        principalColumn: "roleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    cartId = table.Column<long>(type: "bigint", nullable: false),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    totalPrice = table.Column<int>(type: "int", nullable: false),
                    createAt = table.Column<DateTime>(type: "date", nullable: false),
                    promocodeId = table.Column<long>(type: "bigint", nullable: true),
                    paymentType = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false),
                    endAt = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => new { x.cartId, x.userId });
                    table.ForeignKey(
                        name: "FK_Cart_Promocode",
                        column: x => x.promocodeId,
                        principalTable: "Promocode",
                        principalColumn: "promocodeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cart_User",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovieRating",
                columns: table => new
                {
                    movieRattingtId = table.Column<long>(type: "bigint", nullable: false),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    movieId = table.Column<long>(type: "bigint", nullable: false),
                    comment = table.Column<string>(type: "char(1000)", unicode: false, fixedLength: true, maxLength: 1000, nullable: true),
                    mark = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieRating", x => new { x.movieRattingtId, x.userId, x.movieId });
                    table.ForeignKey(
                        name: "FK_MovieRating_Movie",
                        column: x => x.movieId,
                        principalTable: "Movie",
                        principalColumn: "movieId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieRating_User",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    roleId = table.Column<long>(type: "bigint", nullable: false),
                    userRolesID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.userId, x.roleId, x.userRolesID });
                    table.ForeignKey(
                        name: "FK_UserRoles_Role",
                        column: x => x.roleId,
                        principalTable: "Role",
                        principalColumn: "roleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_User",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovieSubcategories",
                columns: table => new
                {
                    movieSubcategoriesId = table.Column<long>(type: "bigint", nullable: false),
                    subcategoryId = table.Column<long>(type: "bigint", nullable: false),
                    movieId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieSubcategories", x => new { x.movieSubcategoriesId, x.subcategoryId, x.movieId });
                    table.ForeignKey(
                        name: "FK_MovieSubcategories_Movie",
                        column: x => x.movieId,
                        principalTable: "Movie",
                        principalColumn: "movieId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieSubcategories_Subcategory",
                        column: x => x.subcategoryId,
                        principalTable: "Subcategory",
                        principalColumn: "subcategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hall",
                columns: table => new
                {
                    hallId = table.Column<long>(type: "bigint", nullable: false),
                    cinemaId = table.Column<long>(type: "bigint", nullable: false),
                    hallName = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    hallSeatsNumber = table.Column<long>(type: "bigint", nullable: false),
                    format = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hall", x => new { x.hallId, x.cinemaId });
                    table.ForeignKey(
                        name: "FK_Hall_Cinema",
                        column: x => x.cinemaId,
                        principalTable: "Cinema",
                        principalColumn: "cinemaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartProducts",
                columns: table => new
                {
                    cartProductId = table.Column<long>(type: "bigint", nullable: false),
                    productId = table.Column<long>(type: "bigint", nullable: false),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    cartId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProducts_1", x => new { x.cartProductId, x.productId, x.userId, x.cartId });
                    table.ForeignKey(
                        name: "FK_CartProducts_Cart",
                        columns: x => new { x.cartId, x.userId },
                        principalTable: "Cart",
                        principalColumns: new[] { "cartId", "userId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartProducts_Product",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    seatId = table.Column<long>(type: "bigint", nullable: false),
                    hallId = table.Column<long>(type: "bigint", nullable: false),
                    cinemaId = table.Column<long>(type: "bigint", nullable: false),
                    seatRow = table.Column<int>(type: "int", nullable: false),
                    seatNumber = table.Column<int>(type: "int", nullable: false),
                    @class = table.Column<bool>(name: "class", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => new { x.seatId, x.hallId, x.cinemaId });
                    table.UniqueConstraint("AK_Seat_seatId_hallId", x => new { x.seatId, x.hallId });
                    table.ForeignKey(
                        name: "FK_Seat_Hall",
                        columns: x => new { x.hallId, x.cinemaId },
                        principalTable: "Hall",
                        principalColumns: new[] { "hallId", "cinemaId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    sessiond = table.Column<long>(type: "bigint", nullable: false),
                    movieId = table.Column<long>(type: "bigint", nullable: false),
                    hallId = table.Column<long>(type: "bigint", nullable: false),
                    demonstrationId = table.Column<long>(type: "bigint", nullable: false),
                    screenStart = table.Column<DateTime>(type: "date", nullable: false),
                    screenEnd = table.Column<DateTime>(type: "date", nullable: false),
                    cinamaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session_1", x => new { x.sessiond, x.movieId, x.hallId, x.demonstrationId });
                    table.ForeignKey(
                        name: "FK_Session_Demonstration",
                        column: x => x.demonstrationId,
                        principalTable: "Demonstration",
                        principalColumn: "demonstrationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Session_Hall",
                        columns: x => new { x.hallId, x.cinamaId },
                        principalTable: "Hall",
                        principalColumns: new[] { "hallId", "cinemaId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Session_Movie",
                        column: x => x.movieId,
                        principalTable: "Movie",
                        principalColumn: "movieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    ticketId = table.Column<long>(type: "bigint", nullable: false),
                    seatId = table.Column<long>(type: "bigint", nullable: false),
                    hallId = table.Column<long>(type: "bigint", nullable: false),
                    sessionId = table.Column<long>(type: "bigint", nullable: false),
                    movieId = table.Column<long>(type: "bigint", nullable: false),
                    cinemaId = table.Column<long>(type: "bigint", nullable: false),
                    cartId = table.Column<long>(type: "bigint", nullable: false),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    demonstrationId = table.Column<long>(type: "bigint", nullable: false),
                    createdAt = table.Column<DateTime>(type: "date", nullable: false),
                    ticketPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => new { x.ticketId, x.seatId, x.hallId, x.sessionId, x.movieId, x.cinemaId, x.cartId, x.userId, x.demonstrationId });
                    table.ForeignKey(
                        name: "FK_Ticket_Cart",
                        columns: x => new { x.cartId, x.userId },
                        principalTable: "Cart",
                        principalColumns: new[] { "cartId", "userId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Seat1",
                        columns: x => new { x.seatId, x.hallId },
                        principalTable: "Seat",
                        principalColumns: new[] { "seatId", "hallId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Session1",
                        columns: x => new { x.sessionId, x.movieId, x.hallId, x.demonstrationId },
                        principalTable: "Session",
                        principalColumns: new[] { "sessiond", "movieId", "hallId", "demonstrationId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_promocodeId",
                table: "Cart",
                column: "promocodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_userId",
                table: "Cart",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_cartId_userId",
                table: "CartProducts",
                columns: new[] { "cartId", "userId" });

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_productId",
                table: "CartProducts",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Cinema_cityId",
                table: "Cinema",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "IX_Hall_cinemaId",
                table: "Hall",
                column: "cinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_cityId",
                table: "Location",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieRating_movieId",
                table: "MovieRating",
                column: "movieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieRating_userId",
                table: "MovieRating",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSubcategories_movieId",
                table: "MovieSubcategories",
                column: "movieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSubcategories_subcategoryId",
                table: "MovieSubcategories",
                column: "subcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_permissionId",
                table: "RolePermissions",
                column: "permissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_roleId",
                table: "RolePermissions",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "FK_Seat",
                table: "Seat",
                columns: new[] { "seatId", "hallId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seat_hallId_cinemaId",
                table: "Seat",
                columns: new[] { "hallId", "cinemaId" });

            migrationBuilder.CreateIndex(
                name: "IX_Session_demonstrationId",
                table: "Session",
                column: "demonstrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_hallId_cinamaId",
                table: "Session",
                columns: new[] { "hallId", "cinamaId" });

            migrationBuilder.CreateIndex(
                name: "IX_Session_movieId",
                table: "Session",
                column: "movieId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategory_categoryId",
                table: "Subcategory",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_cartId_userId",
                table: "Ticket",
                columns: new[] { "cartId", "userId" });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_seatId_hallId",
                table: "Ticket",
                columns: new[] { "seatId", "hallId" });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_sessionId_movieId_hallId_demonstrationId",
                table: "Ticket",
                columns: new[] { "sessionId", "movieId", "hallId", "demonstrationId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_roleId",
                table: "UserRoles",
                column: "roleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartProducts");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "MovieRating");

            migrationBuilder.DropTable(
                name: "MovieSubcategories");

            migrationBuilder.DropTable(
                name: "Reciept");

            migrationBuilder.DropTable(
                name: "reservedTicket");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Subcategory");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Promocode");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Demonstration");

            migrationBuilder.DropTable(
                name: "Hall");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Cinema");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
