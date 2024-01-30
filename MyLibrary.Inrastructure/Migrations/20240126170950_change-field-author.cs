using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLibrary.Inrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changefieldauthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Books",
                newName: "AuthorName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AuthorName",
                table: "Books",
                newName: "Author");
        }
    }
}
