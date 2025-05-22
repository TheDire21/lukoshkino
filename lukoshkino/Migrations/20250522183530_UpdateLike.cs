using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lukoshkino.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLike : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Likes_ProductId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Likes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                columns: new[] { "ProductId", "UserId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Likes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_ProductId",
                table: "Likes",
                column: "ProductId");
        }
    }
}
