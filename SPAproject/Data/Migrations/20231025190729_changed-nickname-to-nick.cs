using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPAproject.Data.Migrations
{
    /// <inheritdoc />
    public partial class changednicknametonick : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nickname",
                table: "AspNetUsers",
                newName: "Nick");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nick",
                table: "AspNetUsers",
                newName: "Nickname");
        }
    }
}
