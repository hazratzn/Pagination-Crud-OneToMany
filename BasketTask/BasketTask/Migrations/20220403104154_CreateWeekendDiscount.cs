using Microsoft.EntityFrameworkCore.Migrations;

namespace BasketTask.Migrations
{
    public partial class CreateWeekendDiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeekendDiscounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discount = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Decription = table.Column<string>(nullable: true),
                    Images = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekendDiscounts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeekendDiscounts");
        }
    }
}
