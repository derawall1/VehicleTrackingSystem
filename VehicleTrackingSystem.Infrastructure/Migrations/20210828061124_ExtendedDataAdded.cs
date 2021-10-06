using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleTrackingSystem.Infrastructure.Migrations
{
    public partial class ExtendedDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ExtendedData",
                table: "Vehicle",
                type: "Text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ExtendedData",
                table: "Vehicle",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Text",
                oldNullable: true);
        }
    }
}
