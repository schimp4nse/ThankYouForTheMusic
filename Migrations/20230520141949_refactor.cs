using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class refactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Playlists_Bookmarks_FK",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Bookmarks_Files_FK",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Playlists_Playlist_FK",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_Playlist_FK",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Playlist_FK",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "Files_FK",
                table: "Files",
                newName: "BookmarkId");

            migrationBuilder.RenameIndex(
                name: "IX_Files_Files_FK",
                table: "Files",
                newName: "IX_Files_BookmarkId");

            migrationBuilder.RenameColumn(
                name: "Bookmarks_FK",
                table: "Bookmarks",
                newName: "PlaylistId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookmarks_Bookmarks_FK",
                table: "Bookmarks",
                newName: "IX_Bookmarks_PlaylistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Playlists_PlaylistId",
                table: "Bookmarks",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "PlaylistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Bookmarks_BookmarkId",
                table: "Files",
                column: "BookmarkId",
                principalTable: "Bookmarks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Playlists_PlaylistId",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Bookmarks_BookmarkId",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "BookmarkId",
                table: "Files",
                newName: "Files_FK");

            migrationBuilder.RenameIndex(
                name: "IX_Files_BookmarkId",
                table: "Files",
                newName: "IX_Files_Files_FK");

            migrationBuilder.RenameColumn(
                name: "PlaylistId",
                table: "Bookmarks",
                newName: "Bookmarks_FK");

            migrationBuilder.RenameIndex(
                name: "IX_Bookmarks_PlaylistId",
                table: "Bookmarks",
                newName: "IX_Bookmarks_Bookmarks_FK");

            migrationBuilder.AddColumn<long>(
                name: "Playlist_FK",
                table: "Files",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Files_Playlist_FK",
                table: "Files",
                column: "Playlist_FK");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Playlists_Playlist_FK",
                table: "Files",
                column: "Playlist_FK",
                principalTable: "Playlists",
                principalColumn: "PlaylistId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
