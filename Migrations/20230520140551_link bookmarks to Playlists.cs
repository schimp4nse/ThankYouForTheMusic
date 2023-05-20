using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class linkbookmarkstoPlaylists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Files_FK",
                table: "Files",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Bookmarks_FK",
                table: "Bookmarks",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_Files_FK",
                table: "Files",
                column: "Files_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_Bookmarks_FK",
                table: "Bookmarks",
                column: "Bookmarks_FK");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Playlists_Bookmarks_FK",
                table: "Bookmarks",
                column: "Bookmarks_FK",
                principalTable: "Playlists",
                principalColumn: "PlaylistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Bookmarks_Files_FK",
                table: "Files",
                column: "Files_FK",
                principalTable: "Bookmarks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Playlists_Bookmarks_FK",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Bookmarks_Files_FK",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_Files_FK",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Bookmarks_Bookmarks_FK",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "Files_FK",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Bookmarks_FK",
                table: "Bookmarks");
        }
    }
}
