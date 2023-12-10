using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asp_net_parcijalni_ispit_Ivan_Blazun.Data.Migrations
{
    public partial class UserRelationChanges2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TodoLists_UserId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TodoLists",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_TodoLists_UserId",
                table: "TodoLists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoLists_AspNetUsers_UserId",
                table: "TodoLists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoLists_AspNetUsers_UserId",
                table: "TodoLists");

            migrationBuilder.DropIndex(
                name: "IX_TodoLists_UserId",
                table: "TodoLists");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TodoLists",
                type: "int",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserId",
                table: "AspNetUsers",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TodoLists_UserId",
                table: "AspNetUsers",
                column: "UserId",
                principalTable: "TodoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
