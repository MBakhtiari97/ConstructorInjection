using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_AppUser_UserId",
                table: "UserAddress");

            migrationBuilder.DropIndex(
                name: "IX_UserAddress_UserId",
                table: "UserAddress");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserAddress");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "UserAddress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_AppUserId",
                table: "UserAddress",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_AppUser_AppUserId",
                table: "UserAddress",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_AppUser_AppUserId",
                table: "UserAddress");

            migrationBuilder.DropIndex(
                name: "IX_UserAddress_AppUserId",
                table: "UserAddress");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "UserAddress");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserAddress",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_UserId",
                table: "UserAddress",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_AppUser_UserId",
                table: "UserAddress",
                column: "UserId",
                principalTable: "AppUser",
                principalColumn: "Id");
        }
    }
}
