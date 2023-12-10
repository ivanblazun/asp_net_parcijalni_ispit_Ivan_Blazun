using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asp_net_parcijalni_ispit_Ivan_Blazun.Data.Migrations
{
    public partial class UserRelationChanges3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TodoListId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TodoListId",
                table: "AspNetUsers",
                column: "TodoListId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TodoLists_TodoListId",
                table: "AspNetUsers",
                column: "TodoListId",
                principalTable: "TodoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TodoLists_TodoListId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TodoListId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TodoListId",
                table: "AspNetUsers");
        }
    }
}
