using Microsoft.EntityFrameworkCore.Migrations;

namespace AbpQa263Demo.Migrations
{
    public partial class Added_IsHostUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHostUser",
                table: "AbpUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHostUser",
                table: "AbpUsers");
        }
    }
}
