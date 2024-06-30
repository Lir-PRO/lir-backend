using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules.Chats.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserChatEntityUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChats_Users_ChatId",
                schema: "chats",
                table: "UserChats");

            migrationBuilder.DropColumn(
                name: "RefId",
                schema: "chats",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "chats",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "chats",
                table: "UserChats",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "chats",
                table: "Messages",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_UserChats_Users_UserId",
                schema: "chats",
                table: "UserChats",
                column: "UserId",
                principalSchema: "chats",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChats_Users_UserId",
                schema: "chats",
                table: "UserChats");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "chats",
                table: "Users",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "RefId",
                schema: "chats",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "chats",
                table: "UserChats",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "chats",
                table: "Messages",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_UserChats_Users_ChatId",
                schema: "chats",
                table: "UserChats",
                column: "ChatId",
                principalSchema: "chats",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
