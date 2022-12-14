using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_053502_KHARLAP.Migrations
{
    public partial class fifthmigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvatarImage",
                table: "AspNetUsers",
                newName: "Image");

            migrationBuilder.AddColumn<string>(
                name: "MimeType",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MimeType",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "AspNetUsers",
                newName: "AvatarImage");
        }
    }
}
