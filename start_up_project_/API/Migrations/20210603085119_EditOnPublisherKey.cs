using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class EditOnPublisherKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Publishers",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Publishers",
                newName: "id");
        }
    }
}
