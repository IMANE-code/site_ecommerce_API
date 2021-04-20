using Microsoft.EntityFrameworkCore.Migrations;

namespace produit.Migrations
{
    public partial class iniiii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "paniers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "paniers");

            migrationBuilder.CreateTable(
                name: "commandes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commandes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "commandes");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "paniers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "paniers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
