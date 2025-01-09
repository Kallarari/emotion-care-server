using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EmotionCareServer.Migrations
{
    /// <inheritdoc />
    public partial class AddDiaryPage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiaryPages",
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
                        principalTable: "Psychologists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiaryPages_PsychologistId",
                table: "DiaryPages",
                column: "PsychologistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiaryPages");
        }
    }
}
