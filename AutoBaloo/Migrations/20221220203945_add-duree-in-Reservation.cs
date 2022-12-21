using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoBaloo.Migrations
{
    public partial class adddureeinReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "duree",
                table: "ShoppingCartItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "duree",
                table: "ShoppingCartItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
