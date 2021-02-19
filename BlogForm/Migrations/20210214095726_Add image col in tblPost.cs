using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogForm.Migrations
{
    public partial class AddimagecolintblPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "tblPosts",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "tblPosts");
        }
    }
}
