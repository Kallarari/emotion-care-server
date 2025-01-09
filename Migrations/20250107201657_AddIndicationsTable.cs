using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EmotionCareServer.Migrations
{
    /// <inheritdoc />
    public partial class AddIndicationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Indications",
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
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Indications_Psychologists_PsychologistId",
                        column: x => x.PsychologistId,
                        principalTable: "Psychologists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PsychologistId",
                table: "Patients",
                column: "PsychologistId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_PsychologistId",
                table: "Notifications",
                column: "PsychologistId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Indications_PatientId",
                table: "Indications",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Indications_PsychologistId",
                table: "Indications",
                column: "PsychologistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Patients_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Psychologists_PsychologistId",
                table: "Notifications",
                column: "PsychologistId",
                principalTable: "Psychologists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Psychologists_PsychologistId",
                table: "Patients",
                column: "PsychologistId",
                principalTable: "Psychologists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Patients_UserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Psychologists_PsychologistId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Psychologists_PsychologistId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "Indications");

            migrationBuilder.DropIndex(
                name: "IX_Patients_PsychologistId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_PsychologistId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications");
        }
    }
}
