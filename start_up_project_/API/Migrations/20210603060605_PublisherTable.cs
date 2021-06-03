using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class PublisherTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Address = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Phone = table.Column<string>(type: "varchar", nullable: true),
                    Email = table.Column<string>(type: "varchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
