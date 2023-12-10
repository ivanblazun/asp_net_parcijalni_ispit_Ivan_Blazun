using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asp_net_parcijalni_ispit_Ivan_Blazun.Data.Migrations
{
    public partial class UsertodoListNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TodoLists_TodoListId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "TodoListId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TodoLists_TodoListId",
                table: "AspNetUsers",
                column: "TodoListId",
                principalTable: "TodoLists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TodoLists_TodoListId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "TodoListId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TodoLists_TodoListId",
                table: "AspNetUsers",
                column: "TodoListId",
                principalTable: "TodoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
