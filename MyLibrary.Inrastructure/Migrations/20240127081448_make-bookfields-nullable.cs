﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLibrary.Inrastructure.Migrations
{
    /// <inheritdoc />
    public partial class makebookfieldsnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Shelfs_ShelfId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "ShelfId",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Shelfs_ShelfId",
                table: "Books",
                column: "ShelfId",
                principalTable: "Shelfs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Shelfs_ShelfId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "ShelfId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Shelfs_ShelfId",
                table: "Books",
                column: "ShelfId",
                principalTable: "Shelfs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
