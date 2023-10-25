using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPAproject.Data.Migrations
{
    /// <inheritdoc />
    public partial class changedGameModelboolname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Game",
                table: "Games",
                newName: "GameFinished");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GameFinished",
                table: "Games",
                newName: "Game");
        }
    }
}
