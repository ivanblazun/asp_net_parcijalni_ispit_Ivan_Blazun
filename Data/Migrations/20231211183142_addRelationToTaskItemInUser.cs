using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asp_net_parcijalni_ispit_Ivan_Blazun.Data.Migrations
{
    public partial class addRelationToTaskItemInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_AspNetUsers_UserId",
                table: "TaskItems");

            migrationBuilder.DropIndex(
                name: "IX_TaskItems_UserId",
                table: "TaskItems");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TaskItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaskItemId",
                table: "TaskItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_TaskItemId",
                table: "TaskItems",
                column: "TaskItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_AspNetUsers_TaskItemId",
                table: "TaskItems",
                column: "TaskItemId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_AspNetUsers_TaskItemId",
                table: "TaskItems");

            migrationBuilder.DropIndex(
                name: "IX_TaskItems_TaskItemId",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "TaskItemId",
                table: "TaskItems");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TaskItems",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_UserId",
                table: "TaskItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_AspNetUsers_UserId",
                table: "TaskItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
