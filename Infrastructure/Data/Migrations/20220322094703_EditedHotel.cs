using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    public partial class EditedHotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxPrice",
                table: "Hotels");

            migrationBuilder.RenameColumn(
                name: "MinPrice",
                table: "Hotels",
                newName: "Price");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Hotels",
                newName: "MinPrice");

            migrationBuilder.AddColumn<int>(
                name: "MaxPrice",
                table: "Hotels",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
