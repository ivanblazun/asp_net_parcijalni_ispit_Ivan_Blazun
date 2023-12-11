using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asp_net_parcijalni_ispit_Ivan_Blazun.Data.Migrations
{
    public partial class listModelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoLists_AspNetUsers_UserId",
                table: "TodoLists");

            migrationBuilder.DropIndex(
                name: "IX_TodoLists_UserId",
                table: "TodoLists");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TodoListId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TodoLists",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TodoListId",
                table: "AspNetUsers",
                column: "TodoListId",
                unique: true,
                filter: "[TodoListId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TodoListId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TodoLists",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_TodoLists_UserId",
                table: "TodoLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TodoListId",
                table: "AspNetUsers",
                column: "TodoListId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoLists_AspNetUsers_UserId",
                table: "TodoLists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
