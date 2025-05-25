using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddTestDatav2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Local));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
