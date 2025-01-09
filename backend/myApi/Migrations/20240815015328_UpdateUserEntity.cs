using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Tweet",
                keyColumn: "TweetId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 14, 21, 53, 27, 368, DateTimeKind.Local).AddTicks(1591));

            migrationBuilder.UpdateData(
                table: "Tweet",
                keyColumn: "TweetId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 14, 21, 53, 27, 368, DateTimeKind.Local).AddTicks(1594));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Tweet",
                keyColumn: "TweetId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 13, 18, 41, 2, 249, DateTimeKind.Local).AddTicks(7299));

            migrationBuilder.UpdateData(
                table: "Tweet",
                keyColumn: "TweetId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 13, 18, 41, 2, 249, DateTimeKind.Local).AddTicks(7304));
        }
    }
}
