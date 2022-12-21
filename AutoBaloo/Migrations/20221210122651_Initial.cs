using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoBaloo.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarqueVehicule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeCarbu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrixVehicule = table.Column<double>(type: "float", nullable: false),
                    DescriptionVehicule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateConstruct = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionVehicule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CouleurVehicule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateArrivé = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prix_par_jour = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDebut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateFin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duree = table.Column<int>(type: "int", nullable: false),
                    TypeReservation = table.Column<int>(type: "int", nullable: false),
                    montantReservation = table.Column<double>(type: "float", nullable: false),
                    IdVehicule = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Vehicules_IdVehicule",
                        column: x => x.IdVehicule,
                        principalTable: "Vehicules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatutVehicule = table.Column<int>(type: "int", nullable: false),
                    IdVehicule = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statuts_Vehicules_IdVehicule",
                        column: x => x.IdVehicule,
                        principalTable: "Vehicules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateStock = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QteStock = table.Column<int>(type: "int", nullable: false),
                    IdVehicule = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Vehicules_IdVehicule",
                        column: x => x.IdVehicule,
                        principalTable: "Vehicules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_IdVehicule",
                table: "Reservations",
                column: "IdVehicule");

            migrationBuilder.CreateIndex(
                name: "IX_Statuts_IdVehicule",
                table: "Statuts",
                column: "IdVehicule");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_IdVehicule",
                table: "Stocks",
                column: "IdVehicule");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Statuts");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Vehicules");
        }
    }
}
