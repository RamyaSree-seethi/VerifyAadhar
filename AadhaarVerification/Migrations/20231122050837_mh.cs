using Microsoft.EntityFrameworkCore.Migrations;

namespace AadhaarVerification.Migrations
{
    public partial class mh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumnetPath",
                table: "Data",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumnetPath",
                table: "Data");
        }
    }
}
