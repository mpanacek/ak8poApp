using Microsoft.EntityFrameworkCore.Migrations;

namespace SecretaryApp.EntityFramework.Migrations
{
    public partial class WorklabelNameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "WorkLabels",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "WorkLabels");
        }
    }
}
