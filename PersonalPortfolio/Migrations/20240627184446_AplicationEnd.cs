using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalPortfolio.Migrations
{
    /// <inheritdoc />
    public partial class AplicationEnd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Experiences",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "Aptitudes",
                table: "Experiences");

            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                table: "Experiences",
                type: "TEXT",
                maxLength: 230,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 230);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Experiences",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Experiences",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Experiences",
                table: "Experiences",
                column: "Title");

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: false),
                    ExperienceTitle = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Experiences_ExperienceTitle",
                        column: x => x.ExperienceTitle,
                        principalTable: "Experiences",
                        principalColumn: "Title");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_ExperienceTitle",
                table: "Skills",
                column: "ExperienceTitle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Experiences",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Experiences");

            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                table: "Experiences",
                type: "TEXT",
                maxLength: 230,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 230,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Experiences",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "Aptitudes",
                table: "Experiences",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Experiences",
                table: "Experiences",
                column: "Id");
        }
    }
}
