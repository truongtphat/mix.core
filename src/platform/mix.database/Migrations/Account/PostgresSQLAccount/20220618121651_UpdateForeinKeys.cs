﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mix.Database.Migrations.PostgresSQLAccount
{
    public partial class UpdateForeinKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_MixUsers_MixUserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_MixUsers_MixUserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_MixUsers_MixUserId1",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_MixUsers_MixUserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_MixUsers_MixUserId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_MixUsers_MixUserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserTokens_MixUserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_MixUserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_MixUserId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserLogins_MixUserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserLogins_MixUserId1",
                table: "AspNetUserLogins");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserClaims_MixUserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropColumn(
                name: "MixUserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropColumn(
                name: "MixUserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "MixUserId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "MixUserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropColumn(
                name: "MixUserId1",
                table: "AspNetUserLogins");

            migrationBuilder.DropColumn(
                name: "MixUserId",
                table: "AspNetUserClaims");

            migrationBuilder.RenameColumn(
                name: "CreatedDatetime",
                table: "MixUsers",
                newName: "CreatedDateTime");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "RefreshTokens",
                type: "varchar(250)",
                nullable: true,
                collation: "und-x-icu",
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldCollation: "und-x-icu");

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "MixUsers",
                type: "varchar(250)",
                nullable: true,
                collation: "und-x-icu");

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "MixUsers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "MixUsers",
                type: "varchar(50)",
                nullable: true,
                collation: "und-x-icu");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "MixUsers",
                type: "varchar(50)",
                nullable: true,
                collation: "und-x-icu");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "MixUsers",
                type: "varchar(50)",
                nullable: true,
                collation: "und-x-icu");

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "MixUsers",
                type: "varchar(50)",
                nullable: true,
                collation: "und-x-icu");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_MixUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "MixUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_MixUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "MixUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_MixUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "MixUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_MixUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "MixUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_MixUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_MixUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_MixUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_MixUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "MixUsers");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "MixUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "MixUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "MixUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "MixUsers");

            migrationBuilder.DropColumn(
                name: "NickName",
                table: "MixUsers");

            migrationBuilder.RenameColumn(
                name: "CreatedDateTime",
                table: "MixUsers",
                newName: "CreatedDatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "RefreshTokens",
                type: "varchar(250)",
                nullable: false,
                defaultValue: "",
                collation: "und-x-icu",
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldNullable: true,
                oldCollation: "und-x-icu");

            migrationBuilder.AddColumn<Guid>(
                name: "MixUserId",
                table: "AspNetUserTokens",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MixUserId",
                table: "AspNetUserRoles",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MixUserId1",
                table: "AspNetUserRoles",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MixUserId",
                table: "AspNetUserLogins",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MixUserId1",
                table: "AspNetUserLogins",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MixUserId",
                table: "AspNetUserClaims",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserTokens_MixUserId",
                table: "AspNetUserTokens",
                column: "MixUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_MixUserId",
                table: "AspNetUserRoles",
                column: "MixUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_MixUserId1",
                table: "AspNetUserRoles",
                column: "MixUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_MixUserId",
                table: "AspNetUserLogins",
                column: "MixUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_MixUserId1",
                table: "AspNetUserLogins",
                column: "MixUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_MixUserId",
                table: "AspNetUserClaims",
                column: "MixUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_MixUsers_MixUserId",
                table: "AspNetUserClaims",
                column: "MixUserId",
                principalTable: "MixUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_MixUsers_MixUserId",
                table: "AspNetUserLogins",
                column: "MixUserId",
                principalTable: "MixUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_MixUsers_MixUserId1",
                table: "AspNetUserLogins",
                column: "MixUserId1",
                principalTable: "MixUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_MixUsers_MixUserId",
                table: "AspNetUserRoles",
                column: "MixUserId",
                principalTable: "MixUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_MixUsers_MixUserId1",
                table: "AspNetUserRoles",
                column: "MixUserId1",
                principalTable: "MixUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_MixUsers_MixUserId",
                table: "AspNetUserTokens",
                column: "MixUserId",
                principalTable: "MixUsers",
                principalColumn: "Id");
        }
    }
}