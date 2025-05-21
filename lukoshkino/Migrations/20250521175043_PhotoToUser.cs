using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lukoshkino.Migrations
{
    /// <inheritdoc />
    public partial class PhotoToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FileId",
                table: "AspNetUsers",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Files_FileId",
                table: "AspNetUsers",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Files_FileId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FileId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "AspNetUsers");
        }
    }
}
