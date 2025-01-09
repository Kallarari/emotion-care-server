using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmotionCareServer.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Psychologists",
                columns: new[] { "Id", "Email", "Name", "OrganizationListId", "Password", "ProfilePicture", "Qualifications", "ScheduleId", "SessionDurationMinutes", "WhatsApp" },
                values: new object[,]
                {
                    { 1, "johndoe@example.com", "Dr. John Doe", 0, "password123", "johndoe.jpg", "Ph.D. in Psychology", 1, 60, "+123456789" },
                    { 2, "janesmith@example.com", "Dr. Jane Smith", 0, "password123", "janesmith.jpg", "M.Sc. in Clinical Psychology", 2, 45, "+987654321" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Age", "Email", "Name", "OrganizationListId", "Password", "ProfilePicture", "PsychologistId" },
                values: new object[,]
                {
                    { 1, 30, "joao@example.com", "João", 1, "12345678", "alice.jpg", 1 },
                    { 2, 25, "bobbrown@example.com", "Bob Brown", 1, "67890", "bob.jpg", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Psychologists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Psychologists",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
