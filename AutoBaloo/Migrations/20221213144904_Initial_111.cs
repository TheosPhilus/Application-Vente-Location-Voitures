using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoBaloo.Migrations
{
    public partial class Initial_111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Reservations_ReservationId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Vehicules_IdVehicule",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Reservations_ReservationId",
                table: "ShoppingCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservation");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "ShoppingCartItems",
                newName: "VehiculeId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItems_ReservationId",
                table: "ShoppingCartItems",
                newName: "IX_ShoppingCartItems_VehiculeId");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "OrderItems",
                newName: "IdVehicule");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ReservationId",
                table: "OrderItems",
                newName: "IX_OrderItems_IdVehicule");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_IdVehicule",
                table: "Reservation",
                newName: "IX_Reservation_IdVehicule");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Vehicules_IdVehicule",
                table: "OrderItems",
                column: "IdVehicule",
                principalTable: "Vehicules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Vehicules_IdVehicule",
                table: "Reservation",
                column: "IdVehicule",
                principalTable: "Vehicules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_OrderItems_Vehicules_IdVehicule",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Vehicules_IdVehicule",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Vehicules_VehiculeId",
                table: "ShoppingCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "Reservations");

            migrationBuilder.RenameColumn(
                name: "VehiculeId",
                table: "ShoppingCartItems",
                newName: "ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItems_VehiculeId",
                table: "ShoppingCartItems",
                newName: "IX_ShoppingCartItems_ReservationId");

            migrationBuilder.RenameColumn(
                name: "IdVehicule",
                table: "OrderItems",
                newName: "ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_IdVehicule",
                table: "OrderItems",
                newName: "IX_OrderItems_ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_IdVehicule",
                table: "Reservations",
                newName: "IX_Reservations_IdVehicule");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Reservations_ReservationId",
                table: "OrderItems",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Vehicules_IdVehicule",
                table: "Reservations",
                column: "IdVehicule",
                principalTable: "Vehicules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Reservations_ReservationId",
                table: "ShoppingCartItems",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
