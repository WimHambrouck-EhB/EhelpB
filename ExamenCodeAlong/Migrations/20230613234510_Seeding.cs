using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenCodeAlong.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projecten",
                columns: new[] { "ProjectNaam", "HuidigBudget", "Status" },
                values: new object[,]
                {
                    { "PROJ_1234", 10000m, 0 },
                    { "PROJ_2345", 20000m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Vestigingen",
                columns: new[] { "Id", "Naam" },
                values: new object[,]
                {
                    { 1, "Antwerpen" },
                    { 2, "Brussel" },
                    { 3, "Gent" },
                    { 4, "Hasselt" },
                    { 5, "Leuven" }
                });

            migrationBuilder.InsertData(
                table: "Personeelsleden",
                columns: new[] { "Id", "Achternaam", "Username", "VestigingId", "Voornaam", "Wachtwoord", "WachtwoordControle" },
                values: new object[,]
                {
                    { 1, "Hambrouck", "wim", 1, "Wim", "admin", "admin" },
                    { 2, "Janssens", "jan", 1, "Jan", "admin", "admin" },
                    { 3, "Pieters", "piet", 2, "Piet", "admin", "admin" },
                    { 4, "Jefsen", "jef", 4, "Jef", "admin", "admin" },
                    { 5, "Karelsen", "karel", 5, "Karel", "admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "PersoneelslidProjecten",
                columns: new[] { "Id", "PersoneelslidId", "ProjectId" },
                values: new object[] { 1, 1, "PROJ_1234" });

            migrationBuilder.InsertData(
                table: "PersoneelslidProjecten",
                columns: new[] { "Id", "PersoneelslidId", "ProjectId" },
                values: new object[] { 2, 2, "PROJ_1234" });

            migrationBuilder.InsertData(
                table: "PersoneelslidProjecten",
                columns: new[] { "Id", "PersoneelslidId", "ProjectId" },
                values: new object[] { 3, 3, "PROJ_1234" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Personeelsleden",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Personeelsleden",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PersoneelslidProjecten",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PersoneelslidProjecten",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PersoneelslidProjecten",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projecten",
                keyColumn: "ProjectNaam",
                keyValue: "PROJ_2345");

            migrationBuilder.DeleteData(
                table: "Vestigingen",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Personeelsleden",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Personeelsleden",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Personeelsleden",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projecten",
                keyColumn: "ProjectNaam",
                keyValue: "PROJ_1234");

            migrationBuilder.DeleteData(
                table: "Vestigingen",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vestigingen",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Vestigingen",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vestigingen",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
