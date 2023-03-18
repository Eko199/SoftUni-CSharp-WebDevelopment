using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P01_HospitalDatabase.Migrations
{
    public partial class AddedMedicamentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientsMedicaments_Medicament_MedicamentId",
                table: "PatientsMedicaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medicament",
                table: "Medicament");

            migrationBuilder.RenameTable(
                name: "Medicament",
                newName: "Medicaments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medicaments",
                table: "Medicaments",
                column: "MedicamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientsMedicaments_Medicaments_MedicamentId",
                table: "PatientsMedicaments",
                column: "MedicamentId",
                principalTable: "Medicaments",
                principalColumn: "MedicamentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientsMedicaments_Medicaments_MedicamentId",
                table: "PatientsMedicaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medicaments",
                table: "Medicaments");

            migrationBuilder.RenameTable(
                name: "Medicaments",
                newName: "Medicament");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medicament",
                table: "Medicament",
                column: "MedicamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientsMedicaments_Medicament_MedicamentId",
                table: "PatientsMedicaments",
                column: "MedicamentId",
                principalTable: "Medicament",
                principalColumn: "MedicamentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
