using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GIVER_PRIMARY_DIAGNOSIS_PrimaryDiagnosisId",
                table: "GIVER");

            migrationBuilder.DropIndex(
                name: "IX_GIVER_PrimaryDiagnosisId",
                table: "GIVER");

            migrationBuilder.DropColumn(
                name: "PrimaryDiagnosisId",
                table: "GIVER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrimaryDiagnosisId",
                table: "GIVER",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GIVER_PrimaryDiagnosisId",
                table: "GIVER",
                column: "PrimaryDiagnosisId");

            migrationBuilder.AddForeignKey(
                name: "FK_GIVER_PRIMARY_DIAGNOSIS_PrimaryDiagnosisId",
                table: "GIVER",
                column: "PrimaryDiagnosisId",
                principalTable: "PRIMARY_DIAGNOSIS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
