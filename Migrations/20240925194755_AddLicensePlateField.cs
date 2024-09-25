using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace congestion_tax_calculator.Migrations
{
    public partial class AddLicensePlateField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LicensePlate",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicensePlate",
                table: "Vehicles");
        }
    }
}
