using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class updaetfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Files_Playlist_FK",
                table: "Playlists");

            migrationBuilder.DropIndex(
                name: "IX_Playlists_Playlist_FK",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "Playlist_FK",
                table: "Playlists");

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
                name: "FK_Files_Playlists_Playlist_FK",
                table: "Files",
                column: "Playlist_FK",
                principalTable: "Playlists",
                principalColumn: "PlaylistId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Playlists_Playlist_FK",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_Playlist_FK",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Playlist_FK",
                table: "Files");

            migrationBuilder.AddColumn<long>(
                name: "Playlist_FK",
                table: "Playlists",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_Playlist_FK",
                table: "Playlists",
                column: "Playlist_FK");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Files_Playlist_FK",
                table: "Playlists",
                column: "Playlist_FK",
                principalTable: "Files",
                principalColumn: "FileId");
        }
    }
}
