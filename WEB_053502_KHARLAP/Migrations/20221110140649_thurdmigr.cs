using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_053502_KHARLAP.Migrations
{
    public partial class thurdmigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Avatar",
                table: "AspNetUsers",
                newName: "AvatarImage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvatarImage",
                table: "AspNetUsers",
                newName: "Avatar");
        }
    }
}
