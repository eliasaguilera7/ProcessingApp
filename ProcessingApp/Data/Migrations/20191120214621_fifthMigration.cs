using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessingApp.Data.Migrations
{
    public partial class fifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyApplicationId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MyApplicationId",
                table: "AspNetUsers",
                column: "MyApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_MyApplication_MyApplicationId",
                table: "AspNetUsers",
                column: "MyApplicationId",
                principalTable: "MyApplication",
                principalColumn: "MyApplicationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MyApplication_MyApplicationId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MyApplicationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MyApplicationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");
        }
    }
}
