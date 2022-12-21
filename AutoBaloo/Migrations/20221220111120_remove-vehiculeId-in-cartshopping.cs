using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoBaloo.Migrations
{
    public partial class removevehiculeIdincartshopping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Vehicules_VehiculeId",
                table: "ShoppingCartItems");

            migrationBuilder.AlterColumn<string>(
                name: "Datearrivée",
                table: "Vehicules",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "VehiculeId",
                table: "ShoppingCartItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Vehicules_VehiculeId",
                table: "ShoppingCartItems",
                column: "VehiculeId",
                principalTable: "Vehicules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Vehicules_VehiculeId",
                table: "ShoppingCartItems");

            migrationBuilder.AlterColumn<string>(
                name: "Datearrivée",
                table: "Vehicules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VehiculeId",
                table: "ShoppingCartItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Vehicules_VehiculeId",
                table: "ShoppingCartItems",
                column: "VehiculeId",
                principalTable: "Vehicules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
