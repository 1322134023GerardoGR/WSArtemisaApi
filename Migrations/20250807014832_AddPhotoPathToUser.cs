using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WSArtemisaApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoPathToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "photo_path",
                table: "users",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "photo_path",
                table: "users");
        }
    }
}
