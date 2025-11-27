using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lukoshkino.Migrations
{
    /// <inheritdoc />
    public partial class Feedback_InHome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isInHome",
                table: "Feedbacks",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isInHome",
                table: "Feedbacks");
        }
    }
}
