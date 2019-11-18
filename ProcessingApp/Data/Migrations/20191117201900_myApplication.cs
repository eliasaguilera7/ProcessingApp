using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessingApp.Data.Migrations
{
    public partial class myApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyApplication",
                columns: table => new
                {
                    MyApplicationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyApplication", x => x.MyApplicationId);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MyApplicationId = table.Column<int>(nullable: false),
                    PropertyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationList_MyApplication_MyApplicationId",
                        column: x => x.MyApplicationId,
                        principalTable: "MyApplication",
                        principalColumn: "MyApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationList_PropertyModel_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "PropertyModel",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationList_MyApplicationId",
                table: "ApplicationList",
                column: "MyApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationList_PropertyId",
                table: "ApplicationList",
                column: "PropertyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationList");

            migrationBuilder.DropTable(
                name: "MyApplication");
        }
    }
}
