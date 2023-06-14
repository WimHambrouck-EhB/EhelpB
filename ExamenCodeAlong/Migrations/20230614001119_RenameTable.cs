using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenCodeAlong.Migrations
{
    public partial class RenameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersoneelslidProjecten_Personeelsleden_PersoneelslidId",
                table: "PersoneelslidProjecten");

            migrationBuilder.DropForeignKey(
                name: "FK_PersoneelslidProjecten_Projecten_ProjectId",
                table: "PersoneelslidProjecten");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersoneelslidProjecten",
                table: "PersoneelslidProjecten");

            migrationBuilder.RenameTable(
                name: "PersoneelslidProjecten",
                newName: "PersoneelslidProject");

            migrationBuilder.RenameIndex(
                name: "IX_PersoneelslidProjecten_ProjectId",
                table: "PersoneelslidProject",
                newName: "IX_PersoneelslidProject_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_PersoneelslidProjecten_PersoneelslidId",
                table: "PersoneelslidProject",
                newName: "IX_PersoneelslidProject_PersoneelslidId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersoneelslidProject",
                table: "PersoneelslidProject",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersoneelslidProject_Personeelsleden_PersoneelslidId",
                table: "PersoneelslidProject",
                column: "PersoneelslidId",
                principalTable: "Personeelsleden",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersoneelslidProject_Projecten_ProjectId",
                table: "PersoneelslidProject",
                column: "ProjectId",
                principalTable: "Projecten",
                principalColumn: "ProjectNaam",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersoneelslidProject_Personeelsleden_PersoneelslidId",
                table: "PersoneelslidProject");

            migrationBuilder.DropForeignKey(
                name: "FK_PersoneelslidProject_Projecten_ProjectId",
                table: "PersoneelslidProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersoneelslidProject",
                table: "PersoneelslidProject");

            migrationBuilder.RenameTable(
                name: "PersoneelslidProject",
                newName: "PersoneelslidProjecten");

            migrationBuilder.RenameIndex(
                name: "IX_PersoneelslidProject_ProjectId",
                table: "PersoneelslidProjecten",
                newName: "IX_PersoneelslidProjecten_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_PersoneelslidProject_PersoneelslidId",
                table: "PersoneelslidProjecten",
                newName: "IX_PersoneelslidProjecten_PersoneelslidId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersoneelslidProjecten",
                table: "PersoneelslidProjecten",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersoneelslidProjecten_Personeelsleden_PersoneelslidId",
                table: "PersoneelslidProjecten",
                column: "PersoneelslidId",
                principalTable: "Personeelsleden",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersoneelslidProjecten_Projecten_ProjectId",
                table: "PersoneelslidProjecten",
                column: "ProjectId",
                principalTable: "Projecten",
                principalColumn: "ProjectNaam",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
