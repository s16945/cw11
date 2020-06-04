using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cw8.Migrations
{
    public partial class GeneratedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[] { 1, "doctor@doctor.com", "Jan", "Kowalski" });

            migrationBuilder.InsertData(
                table: "Medicament",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[] { 1, "Works like a charm", "Some medicament", "AB123" });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(2020, 6, 4, 20, 26, 48, 783, DateTimeKind.Local).AddTicks(36), "Jan", "Kowalski" });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 1, new DateTime(2020, 6, 4, 20, 26, 48, 795, DateTimeKind.Local).AddTicks(578), new DateTime(2020, 8, 3, 20, 26, 48, 795, DateTimeKind.Local).AddTicks(911), 1, 1 });

            migrationBuilder.InsertData(
                table: "PrescriptionMedicament",
                columns: new[] { "IdPrescription", "Details", "Dose", "IdMedicament" },
                values: new object[] { 1, "Be careful", 50, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PrescriptionMedicament",
                keyColumn: "IdPrescription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 1);
        }
    }
}
