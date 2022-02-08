using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Migration71 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropColumn(
                name: "EMAIL",
                table: "RECEIVER");

            migrationBuilder.DropColumn(
                name: "PHONE_NUMBER",
                table: "RECEIVER");

            migrationBuilder.DropColumn(
                name: "EMAIL",
                table: "GIVER");

            migrationBuilder.DropColumn(
                name: "PHONE_NUMBER",
                table: "GIVER");

            migrationBuilder.AddColumn<int>(
                name: "CONTACT_INFORMATIONS_ID",
                table: "RECEIVER",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CONTACT_INFORMATIONS_ID",
                table: "GIVER",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContactInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInformations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RECEIVER_CONTACT_INFORMATIONS_ID",
                table: "RECEIVER",
                column: "CONTACT_INFORMATIONS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_GIVER_CONTACT_INFORMATIONS_ID",
                table: "GIVER",
                column: "CONTACT_INFORMATIONS_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_GIVER_ContactInformations_CONTACT_INFORMATIONS_ID",
                table: "GIVER",
                column: "CONTACT_INFORMATIONS_ID",
                principalTable: "ContactInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RECEIVER_ContactInformations_CONTACT_INFORMATIONS_ID",
                table: "RECEIVER",
                column: "CONTACT_INFORMATIONS_ID",
                principalTable: "ContactInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GIVER_ContactInformations_CONTACT_INFORMATIONS_ID",
                table: "GIVER");

            migrationBuilder.DropForeignKey(
                name: "FK_RECEIVER_ContactInformations_CONTACT_INFORMATIONS_ID",
                table: "RECEIVER");

            migrationBuilder.DropTable(
                name: "ContactInformations");

            migrationBuilder.DropIndex(
                name: "IX_RECEIVER_CONTACT_INFORMATIONS_ID",
                table: "RECEIVER");

            migrationBuilder.DropIndex(
                name: "IX_GIVER_CONTACT_INFORMATIONS_ID",
                table: "GIVER");

            migrationBuilder.DropColumn(
                name: "CONTACT_INFORMATIONS_ID",
                table: "RECEIVER");

            migrationBuilder.DropColumn(
                name: "CONTACT_INFORMATIONS_ID",
                table: "GIVER");

            migrationBuilder.AddColumn<string>(
                name: "EMAIL",
                table: "RECEIVER",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PHONE_NUMBER",
                table: "RECEIVER",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EMAIL",
                table: "GIVER",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PHONE_NUMBER",
                table: "GIVER",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }
    }
}
