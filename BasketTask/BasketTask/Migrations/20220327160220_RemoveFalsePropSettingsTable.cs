using Microsoft.EntityFrameworkCore.Migrations;

namespace BasketTask.Migrations
{
    public partial class RemoveFalsePropSettingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Settings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
