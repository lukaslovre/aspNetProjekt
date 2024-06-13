using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Botanio_MVC.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUrlFromPlantImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 1,
                column: "ImageUrl",
                value: "fiddle-leaf-fig");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://via.placeholder.com/150");
        }
    }
}
