using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmotionCareServer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Psychologists",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganizationListId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Qualifications = table.Column<string>(type: "text", nullable: false),
                    WhatsApp = table.Column<string>(type: "text", nullable: false),
                    ScheduleId = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    ProfilePicture = table.Column<string>(type: "text", nullable: false),
                    SessionDurationMinutes = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Psychologists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiaryPages",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SleepSection = table.Column<int>(type: "integer", nullable: true),
                    EventsSection = table.Column<int>(type: "integer", nullable: true),
                    FeelingsSection = table.Column<int>(type: "integer", nullable: true),
                    PredominantThoughtsSection = table.Column<int>(type: "integer", nullable: true),
                    DailyHabitsSection = table.Column<int>(type: "integer", nullable: true),
                    NotesSection = table.Column<int>(type: "integer", nullable: true),
                    DayDescriptionSection = table.Column<int>(type: "integer", nullable: true),
                    PsychologistId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaryPages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiaryPages_Psychologists_PsychologistId",
                        column: x => x.PsychologistId,
                        principalSchema: "public",
                        principalTable: "Psychologists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    ProfilePicture = table.Column<string>(type: "text", nullable: true),
                    PsychologistId = table.Column<int>(type: "integer", nullable: false),
                    OrganizationListId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Psychologists_PsychologistId",
                        column: x => x.PsychologistId,
                        principalSchema: "public",
                        principalTable: "Psychologists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsultationSummaries",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    PsychologistId = table.Column<int>(type: "integer", nullable: false),
                    ConsultationDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultationSummaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultationSummaries_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "public",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultationSummaries_Psychologists_PsychologistId",
                        column: x => x.PsychologistId,
                        principalSchema: "public",
                        principalTable: "Psychologists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Indications",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: true),
                    ImageLink = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    PsychologistId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Indications_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "public",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Indications_Psychologists_PsychologistId",
                        column: x => x.PsychologistId,
                        principalSchema: "public",
                        principalTable: "Psychologists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsPushNotification = table.Column<bool>(type: "boolean", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PsychologistId = table.Column<int>(type: "integer", nullable: false),
                    NotificationType = table.Column<string>(type: "text", nullable: false),
                    Link = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    IsSeen = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Patients_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_Psychologists_PsychologistId",
                        column: x => x.PsychologistId,
                        principalSchema: "public",
                        principalTable: "Psychologists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Psychologists",
                columns: new[] { "Id", "Email", "Name", "OrganizationListId", "Password", "ProfilePicture", "Qualifications", "ScheduleId", "SessionDurationMinutes", "WhatsApp" },
                values: new object[,]
                {
                    { 1, "johndoe@example.com", "Dr. John Doe", 0, "password123", "johndoe.jpg", "Ph.D. in Psychology", 1, 60, "+123456789" },
                    { 2, "janesmith@example.com", "Dr. Jane Smith", 0, "password123", "janesmith.jpg", "M.Sc. in Clinical Psychology", 2, 45, "+987654321" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Patients",
                columns: new[] { "Id", "Age", "Email", "Name", "OrganizationListId", "Password", "ProfilePicture", "PsychologistId" },
                values: new object[,]
                {
                    { 1, 30, "joao@example.com", "João", 1, "12345678", "alice.jpg", 1 },
                    { 2, 25, "bobbrown@example.com", "Bob Brown", 1, "67890", "bob.jpg", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationSummaries_PatientId",
                schema: "public",
                table: "ConsultationSummaries",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationSummaries_PsychologistId",
                schema: "public",
                table: "ConsultationSummaries",
                column: "PsychologistId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaryPages_PsychologistId",
                schema: "public",
                table: "DiaryPages",
                column: "PsychologistId");

            migrationBuilder.CreateIndex(
                name: "IX_Indications_PatientId",
                schema: "public",
                table: "Indications",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Indications_PsychologistId",
                schema: "public",
                table: "Indications",
                column: "PsychologistId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_PsychologistId",
                schema: "public",
                table: "Notifications",
                column: "PsychologistId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                schema: "public",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PsychologistId",
                schema: "public",
                table: "Patients",
                column: "PsychologistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultationSummaries",
                schema: "public");

            migrationBuilder.DropTable(
                name: "DiaryPages",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Indications",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Notifications",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Patients",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Psychologists",
                schema: "public");
        }
    }
}
