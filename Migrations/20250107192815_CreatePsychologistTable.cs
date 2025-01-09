using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmotionCareServer.Migrations
{
    /// <inheritdoc />
    public partial class CreatePsychologistTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_psychologistTable",
                table: "psychologistTable");

            migrationBuilder.RenameTable(
                name: "psychologistTable",
                newName: "Psychologists");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Psychologists",
                newName: "WhatsApp");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Psychologists",
                newName: "Qualifications");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Psychologists",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Psychologists",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OrganizationListId",
                table: "Psychologists",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "Psychologists",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "Psychologists",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SessionDurationMinutes",
                table: "Psychologists",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Psychologists",
                table: "Psychologists",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Psychologists",
                table: "Psychologists");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Psychologists");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Psychologists");

            migrationBuilder.DropColumn(
                name: "OrganizationListId",
                table: "Psychologists");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Psychologists");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Psychologists");

            migrationBuilder.DropColumn(
                name: "SessionDurationMinutes",
                table: "Psychologists");

            migrationBuilder.RenameTable(
                name: "Psychologists",
                newName: "psychologistTable");

            migrationBuilder.RenameColumn(
                name: "WhatsApp",
                table: "psychologistTable",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Qualifications",
                table: "psychologistTable",
                newName: "Descricao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_psychologistTable",
                table: "psychologistTable",
                column: "Id");
        }
    }
}
