using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Receivers",
                table: "Receivers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Givers",
                table: "Givers");

            migrationBuilder.DropColumn(
                name: "PrimaryDiagnosis",
                table: "Receivers");

            migrationBuilder.DropColumn(
                name: "Race",
                table: "Receivers");

            migrationBuilder.DropColumn(
                name: "Race",
                table: "Givers");

            migrationBuilder.RenameTable(
                name: "Receivers",
                newName: "RECEIVER");

            migrationBuilder.RenameTable(
                name: "Givers",
                newName: "GIVER");

            migrationBuilder.RenameColumn(
                name: "Sex",
                table: "RECEIVER",
                newName: "SEX");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "RECEIVER",
                newName: "EMAIL");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "RECEIVER",
                newName: "COUNTRY");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "RECEIVER",
                newName: "CITY");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "RECEIVER",
                newName: "AGE");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RECEIVER",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "RECEIVER",
                newName: "PHONE_NUMBER");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "RECEIVER",
                newName: "LAST_NAME");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "RECEIVER",
                newName: "FIRST_NAME");

            migrationBuilder.RenameColumn(
                name: "BloodType",
                table: "RECEIVER",
                newName: "BLOOD_TYPE");

            migrationBuilder.RenameColumn(
                name: "Sex",
                table: "GIVER",
                newName: "SEX");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "GIVER",
                newName: "EMAIL");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "GIVER",
                newName: "COUNTRY");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "GIVER",
                newName: "CITY");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "GIVER",
                newName: "AGE");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GIVER",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "GIVER",
                newName: "PHONE_NUMBER");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "GIVER",
                newName: "LAST_NAME");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "GIVER",
                newName: "FIRST_NAME");

            migrationBuilder.RenameColumn(
                name: "BloodType",
                table: "GIVER",
                newName: "BLOOD_TYPE");

            migrationBuilder.AddColumn<int>(
                name: "PRIMARY_DIAGNOSIS_ID",
                table: "RECEIVER",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RACE_ID",
                table: "RECEIVER",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrimaryDiagnosisId",
                table: "GIVER",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RACE_ID",
                table: "GIVER",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RECEIVER",
                table: "RECEIVER",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GIVER",
                table: "GIVER",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "PRIMARY_DIAGNOSIS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRIMARY_DIAGNOSIS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RACE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RACE", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RECEIVER_PRIMARY_DIAGNOSIS_ID",
                table: "RECEIVER",
                column: "PRIMARY_DIAGNOSIS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RECEIVER_RACE_ID",
                table: "RECEIVER",
                column: "RACE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_GIVER_PrimaryDiagnosisId",
                table: "GIVER",
                column: "PrimaryDiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_GIVER_RACE_ID",
                table: "GIVER",
                column: "RACE_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_GIVER_PRIMARY_DIAGNOSIS_PrimaryDiagnosisId",
                table: "GIVER",
                column: "PrimaryDiagnosisId",
                principalTable: "PRIMARY_DIAGNOSIS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GIVER_RACE_RACE_ID",
                table: "GIVER",
                column: "RACE_ID",
                principalTable: "RACE",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RECEIVER_PRIMARY_DIAGNOSIS_PRIMARY_DIAGNOSIS_ID",
                table: "RECEIVER",
                column: "PRIMARY_DIAGNOSIS_ID",
                principalTable: "PRIMARY_DIAGNOSIS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RECEIVER_RACE_RACE_ID",
                table: "RECEIVER",
                column: "RACE_ID",
                principalTable: "RACE",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GIVER_PRIMARY_DIAGNOSIS_PrimaryDiagnosisId",
                table: "GIVER");

            migrationBuilder.DropForeignKey(
                name: "FK_GIVER_RACE_RACE_ID",
                table: "GIVER");

            migrationBuilder.DropForeignKey(
                name: "FK_RECEIVER_PRIMARY_DIAGNOSIS_PRIMARY_DIAGNOSIS_ID",
                table: "RECEIVER");

            migrationBuilder.DropForeignKey(
                name: "FK_RECEIVER_RACE_RACE_ID",
                table: "RECEIVER");

            migrationBuilder.DropTable(
                name: "PRIMARY_DIAGNOSIS");

            migrationBuilder.DropTable(
                name: "RACE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RECEIVER",
                table: "RECEIVER");

            migrationBuilder.DropIndex(
                name: "IX_RECEIVER_PRIMARY_DIAGNOSIS_ID",
                table: "RECEIVER");

            migrationBuilder.DropIndex(
                name: "IX_RECEIVER_RACE_ID",
                table: "RECEIVER");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GIVER",
                table: "GIVER");

            migrationBuilder.DropIndex(
                name: "IX_GIVER_PrimaryDiagnosisId",
                table: "GIVER");

            migrationBuilder.DropIndex(
                name: "IX_GIVER_RACE_ID",
                table: "GIVER");

            migrationBuilder.DropColumn(
                name: "PRIMARY_DIAGNOSIS_ID",
                table: "RECEIVER");

            migrationBuilder.DropColumn(
                name: "RACE_ID",
                table: "RECEIVER");

            migrationBuilder.DropColumn(
                name: "PrimaryDiagnosisId",
                table: "GIVER");

            migrationBuilder.DropColumn(
                name: "RACE_ID",
                table: "GIVER");

            migrationBuilder.RenameTable(
                name: "RECEIVER",
                newName: "Receivers");

            migrationBuilder.RenameTable(
                name: "GIVER",
                newName: "Givers");

            migrationBuilder.RenameColumn(
                name: "SEX",
                table: "Receivers",
                newName: "Sex");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "Receivers",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "COUNTRY",
                table: "Receivers",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "CITY",
                table: "Receivers",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "AGE",
                table: "Receivers",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Receivers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PHONE_NUMBER",
                table: "Receivers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "LAST_NAME",
                table: "Receivers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "FIRST_NAME",
                table: "Receivers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "BLOOD_TYPE",
                table: "Receivers",
                newName: "BloodType");

            migrationBuilder.RenameColumn(
                name: "SEX",
                table: "Givers",
                newName: "Sex");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "Givers",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "COUNTRY",
                table: "Givers",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "CITY",
                table: "Givers",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "AGE",
                table: "Givers",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Givers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PHONE_NUMBER",
                table: "Givers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "LAST_NAME",
                table: "Givers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "FIRST_NAME",
                table: "Givers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "BLOOD_TYPE",
                table: "Givers",
                newName: "BloodType");

            migrationBuilder.AddColumn<int>(
                name: "PrimaryDiagnosis",
                table: "Receivers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Race",
                table: "Receivers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Race",
                table: "Givers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receivers",
                table: "Receivers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Givers",
                table: "Givers",
                column: "Id");
        }
    }
}
