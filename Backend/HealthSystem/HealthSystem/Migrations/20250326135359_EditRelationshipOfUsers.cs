using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthSystem.Migrations
{
    /// <inheritdoc />
    public partial class EditRelationshipOfUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Doctors_DoctorUserID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Patients_PatientUserID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DoctorUserID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PatientUserID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DoctorUserID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PatientUserID",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DoctorUserID",
                table: "Users",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PatientUserID",
                table: "Users",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Users_DoctorUserID",
                table: "Users",
                column: "DoctorUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PatientUserID",
                table: "Users",
                column: "PatientUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Doctors_DoctorUserID",
                table: "Users",
                column: "DoctorUserID",
                principalTable: "Doctors",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Patients_PatientUserID",
                table: "Users",
                column: "PatientUserID",
                principalTable: "Patients",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
