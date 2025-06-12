using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MissionBackend.Migrations
{
    /// <inheritdoc />
    public partial class removecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MissionSkill",
                table: "Mission");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MissionSkill",
                table: "Mission",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
