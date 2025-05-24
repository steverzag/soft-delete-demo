using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftDeleteDemo.API.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedFilter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_IsDeleted",
                table: "Users",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_AppTasks_IsDeleted",
                table: "AppTasks",
                column: "IsDeleted",
                filter: "IsDeleted = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_IsDeleted",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_AppTasks_IsDeleted",
                table: "AppTasks");
        }
    }
}
