using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLibrary.Inrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyShelf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Books_ShelfId",
                table: "Books",
                column: "ShelfId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Shelfs_ShelfId",
                table: "Books",
                column: "ShelfId",
                principalTable: "Shelfs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Shelfs_ShelfId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_ShelfId",
                table: "Books");
        }
    }
}
