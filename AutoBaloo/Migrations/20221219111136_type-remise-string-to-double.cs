using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoBaloo.Migrations
{
    public partial class typeremisestringtodouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateArrivé",
                table: "Vehicules");

            migrationBuilder.AlterColumn<double>(
                name: "OptionVehicule",
                table: "Vehicules",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OptionVehicule",
                table: "Vehicules",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "DateArrivé",
                table: "Vehicules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
