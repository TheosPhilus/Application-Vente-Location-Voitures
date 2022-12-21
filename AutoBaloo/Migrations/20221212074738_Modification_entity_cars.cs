using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoBaloo.Migrations
{
    public partial class Modification_entity_cars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeReservation",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "typeAchat",
                table: "Vehicules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "typeAchat",
                table: "Vehicules");

            migrationBuilder.AddColumn<int>(
                name: "TypeReservation",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
