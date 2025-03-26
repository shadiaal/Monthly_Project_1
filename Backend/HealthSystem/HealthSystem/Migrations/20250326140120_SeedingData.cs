using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthSystem.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "FirstName", "LastName", "MiddleName", "Password", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { new Guid("0b352489-50a5-4392-8f48-26290a5ad996"), "michael.martinez@email.com", "Michael", "Martinez", "Ray", "DoctorPassword789", "1234567891", 1 },
                    { new Guid("230ccf11-e50c-4e65-b6e1-effcff230ea3"), "sophia.davis@email.com", "Sophia", "Davis", "Ann", "DoctorPassword456", "9876543211", 1 },
                    { new Guid("26768127-9022-430d-bcb1-b261edd723f0"), "olivia.lopez@email.com", "Olivia", "Lopez", "Marie", "DoctorPassword101", "2345678901", 1 },
                    { new Guid("37a90677-e170-4b8e-84ee-70d63dfc5f0a"), "charlie.brown@email.com", "Charlie", "Brown", "David", "PatientPassword789", "5432168970", 2 },
                    { new Guid("4124b740-9c17-4843-a24d-6be0a13062f3"), "ethan.hernandez@email.com", "Ethan", "Hernandez", "James", "DoctorPassword202", "3456789012", 1 },
                    { new Guid("490277c6-a754-4164-b87c-5d8ea1822906"), "areej.shareefi@email.com", "Areej", "Shareefi", "Osama", "AdminPassword123", "9876543210", 0 },
                    { new Guid("8cf4a402-6456-4d0d-92ad-9231d4d3997a"), "alice.smith@email.com", "Alice", "Smith", "Marie", "PatientPassword123", "3216549870", 2 },
                    { new Guid("9bb75c0e-02a4-48a7-9abc-6c02b2b848db"), "james.wilson@email.com", "James", "Wilson", "Edward", "DoctorPassword123", "8765432109", 1 },
                    { new Guid("b6165ff2-b3ef-47ea-ae51-5721d6f2868b"), "david.williams@email.com", "David", "Williams", "Lee", "PatientPassword101", "6543210987", 2 },
                    { new Guid("e352360f-04db-468b-b134-6fce2e2b732f"), "emma.taylor@email.com", "Emma", "Taylor", "Grace", "PatientPassword202", "7654321098", 2 },
                    { new Guid("fa6aea75-1bc1-47dd-93b2-fb21c4ec16e0"), "bob.johnson@email.com", "Bob", "Johnson", "John", "PatientPassword456", "4321657890", 2 }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "UserID", "Clinic", "Gender", "Specialization" },
                values: new object[,]
                {
                    { new Guid("0b352489-50a5-4392-8f48-26290a5ad996"), 3, 0, "Pediatrics" },
                    { new Guid("230ccf11-e50c-4e65-b6e1-effcff230ea3"), 2, 1, "Dermatology" },
                    { new Guid("26768127-9022-430d-bcb1-b261edd723f0"), 4, 1, "Orthopedics" },
                    { new Guid("4124b740-9c17-4843-a24d-6be0a13062f3"), 5, 0, "Neurology" },
                    { new Guid("9bb75c0e-02a4-48a7-9abc-6c02b2b848db"), 1, 0, "Cardiology" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "UserID", "Allergies", "BloodType", "ChronicDiseases", "DateOfBirth", "Gender", "NationalID" },
                values: new object[,]
                {
                    { new Guid("37a90677-e170-4b8e-84ee-70d63dfc5f0a"), "Latex, Pollen", 2, "None", new DateTime(1995, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "3456789012" },
                    { new Guid("8cf4a402-6456-4d0d-92ad-9231d4d3997a"), "Peanuts, Dust", 0, "Asthma", new DateTime(1990, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "1234567890" },
                    { new Guid("b6165ff2-b3ef-47ea-ae51-5721d6f2868b"), "None", 4, "Hypertension", new DateTime(1983, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "4567890123" },
                    { new Guid("e352360f-04db-468b-b134-6fce2e2b732f"), "Dust, Animal Dander", 6, "Asthma", new DateTime(1992, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "5678901234" },
                    { new Guid("fa6aea75-1bc1-47dd-93b2-fb21c4ec16e0"), "Penicillin", 7, "Diabetes", new DateTime(1988, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "2345678901" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentID", "AppointmentDate", "AppointmentTime", "DoctorUserID", "Note", "PatientUserID", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 27, 17, 1, 19, 869, DateTimeKind.Local).AddTicks(5247), new TimeSpan(0, 10, 0, 0, 0), new Guid("9bb75c0e-02a4-48a7-9abc-6c02b2b848db"), "Initial check-up appointment.", new Guid("8cf4a402-6456-4d0d-92ad-9231d4d3997a"), 0 },
                    { 2, new DateTime(2025, 3, 25, 17, 1, 19, 869, DateTimeKind.Local).AddTicks(5272), new TimeSpan(0, 9, 0, 0, 0), new Guid("9bb75c0e-02a4-48a7-9abc-6c02b2b848db"), "Follow-up appointment.", new Guid("fa6aea75-1bc1-47dd-93b2-fb21c4ec16e0"), 1 },
                    { 3, new DateTime(2025, 3, 29, 17, 1, 19, 869, DateTimeKind.Local).AddTicks(5273), new TimeSpan(0, 14, 30, 0, 0), new Guid("230ccf11-e50c-4e65-b6e1-effcff230ea3"), "Dermatology consultation.", new Guid("37a90677-e170-4b8e-84ee-70d63dfc5f0a"), 0 },
                    { 4, new DateTime(2025, 3, 31, 17, 1, 19, 869, DateTimeKind.Local).AddTicks(5275), new TimeSpan(0, 11, 0, 0, 0), new Guid("0b352489-50a5-4392-8f48-26290a5ad996"), "Pediatric consultation for vaccination.", new Guid("b6165ff2-b3ef-47ea-ae51-5721d6f2868b"), 0 },
                    { 5, new DateTime(2025, 3, 28, 17, 1, 19, 869, DateTimeKind.Local).AddTicks(5277), new TimeSpan(0, 16, 0, 0, 0), new Guid("26768127-9022-430d-bcb1-b261edd723f0"), "Orthopedic consultation for knee pain.", new Guid("e352360f-04db-468b-b134-6fce2e2b732f"), 0 }
                });

            migrationBuilder.InsertData(
                table: "WorkingHours",
                columns: new[] { "WorkingHoursID", "Day", "EndTime", "StartTime", "UserID" },
                values: new object[,]
                {
                    { 1, 1, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0), new Guid("9bb75c0e-02a4-48a7-9abc-6c02b2b848db") },
                    { 2, 2, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), new Guid("230ccf11-e50c-4e65-b6e1-effcff230ea3") },
                    { 3, 3, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0), new Guid("0b352489-50a5-4392-8f48-26290a5ad996") },
                    { 4, 4, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0), new Guid("26768127-9022-430d-bcb1-b261edd723f0") },
                    { 5, 5, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new Guid("4124b740-9c17-4843-a24d-6be0a13062f3") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("490277c6-a754-4164-b87c-5d8ea1822906"));

            migrationBuilder.DeleteData(
                table: "WorkingHours",
                keyColumn: "WorkingHoursID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkingHours",
                keyColumn: "WorkingHoursID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkingHours",
                keyColumn: "WorkingHoursID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorkingHours",
                keyColumn: "WorkingHoursID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WorkingHours",
                keyColumn: "WorkingHoursID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "UserID",
                keyValue: new Guid("0b352489-50a5-4392-8f48-26290a5ad996"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "UserID",
                keyValue: new Guid("230ccf11-e50c-4e65-b6e1-effcff230ea3"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "UserID",
                keyValue: new Guid("26768127-9022-430d-bcb1-b261edd723f0"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "UserID",
                keyValue: new Guid("4124b740-9c17-4843-a24d-6be0a13062f3"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "UserID",
                keyValue: new Guid("9bb75c0e-02a4-48a7-9abc-6c02b2b848db"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "UserID",
                keyValue: new Guid("37a90677-e170-4b8e-84ee-70d63dfc5f0a"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "UserID",
                keyValue: new Guid("8cf4a402-6456-4d0d-92ad-9231d4d3997a"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "UserID",
                keyValue: new Guid("b6165ff2-b3ef-47ea-ae51-5721d6f2868b"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "UserID",
                keyValue: new Guid("e352360f-04db-468b-b134-6fce2e2b732f"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "UserID",
                keyValue: new Guid("fa6aea75-1bc1-47dd-93b2-fb21c4ec16e0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("0b352489-50a5-4392-8f48-26290a5ad996"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("230ccf11-e50c-4e65-b6e1-effcff230ea3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("26768127-9022-430d-bcb1-b261edd723f0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("37a90677-e170-4b8e-84ee-70d63dfc5f0a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("4124b740-9c17-4843-a24d-6be0a13062f3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("8cf4a402-6456-4d0d-92ad-9231d4d3997a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("9bb75c0e-02a4-48a7-9abc-6c02b2b848db"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("b6165ff2-b3ef-47ea-ae51-5721d6f2868b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("e352360f-04db-468b-b134-6fce2e2b732f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("fa6aea75-1bc1-47dd-93b2-fb21c4ec16e0"));
        }
    }
}
