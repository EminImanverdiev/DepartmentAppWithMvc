using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDepartment.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "departmanId",
                table: "personels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_personels_departmanId",
                table: "personels",
                column: "departmanId");

            migrationBuilder.AddForeignKey(
                name: "FK_personels_departmens_departmanId",
                table: "personels",
                column: "departmanId",
                principalTable: "departmens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_personels_departmens_departmanId",
                table: "personels");

            migrationBuilder.DropIndex(
                name: "IX_personels_departmanId",
                table: "personels");

            migrationBuilder.DropColumn(
                name: "departmanId",
                table: "personels");
        }
    }
}
