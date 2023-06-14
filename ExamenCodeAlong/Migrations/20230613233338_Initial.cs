using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenCodeAlong.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projecten",
                columns: table => new
                {
                    ProjectNaam = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    HuidigBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projecten", x => x.ProjectNaam);
                });

            migrationBuilder.CreateTable(
                name: "Vestigingen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vestigingen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personeelsleden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Achternaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wachtwoord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WachtwoordControle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VestigingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personeelsleden", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personeelsleden_Vestigingen_VestigingId",
                        column: x => x.VestigingId,
                        principalTable: "Vestigingen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersoneelslidProjecten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersoneelslidId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersoneelslidProjecten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersoneelslidProjecten_Personeelsleden_PersoneelslidId",
                        column: x => x.PersoneelslidId,
                        principalTable: "Personeelsleden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersoneelslidProjecten_Projecten_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projecten",
                        principalColumn: "ProjectNaam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personeelsleden_VestigingId",
                table: "Personeelsleden",
                column: "VestigingId");

            migrationBuilder.CreateIndex(
                name: "IX_PersoneelslidProjecten_PersoneelslidId",
                table: "PersoneelslidProjecten",
                column: "PersoneelslidId");

            migrationBuilder.CreateIndex(
                name: "IX_PersoneelslidProjecten_ProjectId",
                table: "PersoneelslidProjecten",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersoneelslidProjecten");

            migrationBuilder.DropTable(
                name: "Personeelsleden");

            migrationBuilder.DropTable(
                name: "Projecten");

            migrationBuilder.DropTable(
                name: "Vestigingen");
        }
    }
}
