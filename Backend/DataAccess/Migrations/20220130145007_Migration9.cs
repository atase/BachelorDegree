using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Migration9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GIVER_ContactInformations_CONTACT_INFORMATIONS_ID",
                table: "GIVER");

            migrationBuilder.DropForeignKey(
                name: "FK_RECEIVER_ContactInformations_CONTACT_INFORMATIONS_ID",
                table: "RECEIVER");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactInformations",
                table: "ContactInformations");

            migrationBuilder.RenameTable(
                name: "ContactInformations",
                newName: "CONTACT_INFORMATIONS");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "CONTACT_INFORMATIONS",
                newName: "EMAIL");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CONTACT_INFORMATIONS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "CONTACT_INFORMATIONS",
                newName: "PHONE_NUMBER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CONTACT_INFORMATIONS",
                table: "CONTACT_INFORMATIONS",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "COMPATIBILITIES_SCORES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GIVER_ID = table.Column<int>(type: "int", nullable: false),
                    RECEIVER_ID = table.Column<int>(type: "int", nullable: false),
                    SCORE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPATIBILITIES_SCORES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COMPATIBILITIES_SCORES_GIVER_GIVER_ID",
                        column: x => x.GIVER_ID,
                        principalTable: "GIVER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COMPATIBILITIES_SCORES_RECEIVER_RECEIVER_ID",
                        column: x => x.RECEIVER_ID,
                        principalTable: "RECEIVER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COMPATIBILITIES_SCORES_GIVER_ID",
                table: "COMPATIBILITIES_SCORES",
                column: "GIVER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_COMPATIBILITIES_SCORES_RECEIVER_ID",
                table: "COMPATIBILITIES_SCORES",
                column: "RECEIVER_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_GIVER_CONTACT_INFORMATIONS_CONTACT_INFORMATIONS_ID",
                table: "GIVER",
                column: "CONTACT_INFORMATIONS_ID",
                principalTable: "CONTACT_INFORMATIONS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RECEIVER_CONTACT_INFORMATIONS_CONTACT_INFORMATIONS_ID",
                table: "RECEIVER",
                column: "CONTACT_INFORMATIONS_ID",
                principalTable: "CONTACT_INFORMATIONS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GIVER_CONTACT_INFORMATIONS_CONTACT_INFORMATIONS_ID",
                table: "GIVER");

            migrationBuilder.DropForeignKey(
                name: "FK_RECEIVER_CONTACT_INFORMATIONS_CONTACT_INFORMATIONS_ID",
                table: "RECEIVER");

            migrationBuilder.DropTable(
                name: "COMPATIBILITIES_SCORES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CONTACT_INFORMATIONS",
                table: "CONTACT_INFORMATIONS");

            migrationBuilder.RenameTable(
                name: "CONTACT_INFORMATIONS",
                newName: "ContactInformations");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "ContactInformations",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ContactInformations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PHONE_NUMBER",
                table: "ContactInformations",
                newName: "PhoneNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactInformations",
                table: "ContactInformations",
                column: "Id");

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
    }
}
