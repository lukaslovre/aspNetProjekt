using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Botanio_MVC.Migrations
{
    /// <inheritdoc />
    public partial class AddNameToCareInstructions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CareInstructions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CareInstructions",
                keyColumn: "CareInstructionsId",
                keyValue: 1,
                column: "Name",
                value: "Basic Care Instructions");

            migrationBuilder.UpdateData(
                table: "CareInstructions",
                keyColumn: "CareInstructionsId",
                keyValue: 2,
                column: "Name",
                value: "For Tropical Plants");

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 2,
                column: "ImageUrl",
                value: "SwissCheese.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CareInstructions");

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://via.placeholder.com/150");
        }
    }
}
