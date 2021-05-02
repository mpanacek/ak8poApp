using Microsoft.EntityFrameworkCore.Migrations;

namespace SecretaryApp.EntityFramework.Migrations
{
    public partial class ShortcutColumnRemoval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Subjects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
         
        }
    }
}
