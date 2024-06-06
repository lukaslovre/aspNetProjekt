using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Botanio_MVC.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CareInstructions",
                columns: table => new
                {
                    CareInstructionsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WateringInstructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SunlightInstructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemperatureRangeLow = table.Column<int>(type: "int", nullable: false),
                    TemperatureRangeHigh = table.Column<int>(type: "int", nullable: false),
                    PruningInstructions = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareInstructions", x => x.CareInstructionsId);
                });

            migrationBuilder.CreateTable(
                name: "Habitats",
                columns: table => new
                {
                    HabitatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Climate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoilType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitats", x => x.HabitatId);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    SpeciesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScientificName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.SpeciesId);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    PlantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScientificName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpeciesId = table.Column<int>(type: "int", nullable: false),
                    HabitatId = table.Column<int>(type: "int", nullable: false),
                    CareInstructionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.PlantId);
                    table.ForeignKey(
                        name: "FK_Plants_CareInstructions_CareInstructionsId",
                        column: x => x.CareInstructionsId,
                        principalTable: "CareInstructions",
                        principalColumn: "CareInstructionsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plants_Habitats_HabitatId",
                        column: x => x.HabitatId,
                        principalTable: "Habitats",
                        principalColumn: "HabitatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plants_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "SpeciesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CareInstructions",
                columns: new[] { "CareInstructionsId", "PruningInstructions", "SunlightInstructions", "TemperatureRangeHigh", "TemperatureRangeLow", "WateringInstructions" },
                values: new object[,]
                {
                    { 1, "Prune to shape as needed.", "Bright, indirect light.", 75, 65, "Water when the top inch of soil is dry." },
                    { 2, "Prune to remove dead or damaged leaves.", "Bright, direct light.", 90, 70, "Water sparingly." }
                });

            migrationBuilder.InsertData(
                table: "Habitats",
                columns: new[] { "HabitatId", "Climate", "Location", "Name", "SoilType" },
                values: new object[,]
                {
                    { 1, "Tropical", "Near the equator", "Tropical Rainforest", "Rich, well-draining" },
                    { 2, "Arid", "Hot and dry", "Desert", "Sandy" }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "SpeciesId", "CommonName", "Description", "Origin", "ScientificName" },
                values: new object[,]
                {
                    { 1, "Fiddle Leaf Fig", "The Fiddle Leaf Fig is a popular indoor plant featuring large, violin-shaped leaves.", "West Africa", "Ficus lyrata" },
                    { 2, "Swiss Cheese Plant", "The Swiss Cheese Plant is a tropical plant with large, glossy leaves that develop holes as they mature.", "Central America", "Monstera deliciosa" }
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantId", "CareInstructionsId", "Description", "HabitatId", "ImageUrl", "Name", "ScientificName", "SpeciesId" },
                values: new object[,]
                {
                    { 1, 1, "The Fiddle Leaf Fig is a popular indoor plant featuring large, violin-shaped leaves.", 1, "https://via.placeholder.com/150", "Fiddle Leaf Fig", "Ficus lyrata", 1 },
                    { 2, 2, "The Swiss Cheese Plant is a tropical plant with large, glossy leaves that develop holes as they mature.", 1, "https://via.placeholder.com/150", "Swiss Cheese Plant", "Monstera deliciosa", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plants_CareInstructionsId",
                table: "Plants",
                column: "CareInstructionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_HabitatId",
                table: "Plants",
                column: "HabitatId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_SpeciesId",
                table: "Plants",
                column: "SpeciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "CareInstructions");

            migrationBuilder.DropTable(
                name: "Habitats");

            migrationBuilder.DropTable(
                name: "Species");
        }
    }
}
