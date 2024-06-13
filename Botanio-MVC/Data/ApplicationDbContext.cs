using Botanio_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Botanio_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Plant> Plants { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Habitat> Habitats { get; set; }
        public DbSet<CareInstructions> CareInstructions { get; set; }

        // Seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Species>().HasData(
                new Species
                {
                    SpeciesId = 1,
                    ScientificName = "Ficus lyrata",
                    CommonName = "Fiddle Leaf Fig",
                    Origin = "West Africa",
                    Description = "The Fiddle Leaf Fig is a popular indoor plant featuring large, violin-shaped leaves."
                },
                new Species
                {
                    SpeciesId = 2,
                    ScientificName = "Monstera deliciosa",
                    CommonName = "Swiss Cheese Plant",
                    Origin = "Central America",
                    Description = "The Swiss Cheese Plant is a tropical plant with large, glossy leaves that develop holes as they mature."
                }
            );

            modelBuilder.Entity<Habitat>().HasData(
                new Habitat
                {
                    HabitatId = 1,
                    Name = "Tropical Rainforest",
                    Climate = "Tropical",
                    Location = "Near the equator",
                    SoilType = "Rich, well-draining"
                },
                new Habitat
                {
                    HabitatId = 2,
                    Name = "Desert",
                    Climate = "Arid",
                    Location = "Hot and dry",
                    SoilType = "Sandy"
                }
            );

            modelBuilder.Entity<CareInstructions>().HasData(
                new CareInstructions
                {
                    CareInstructionsId = 1,
                    Name = "Basic Care Instructions",
                    WateringInstructions = "Water when the top inch of soil is dry.",
                    SunlightInstructions = "Bright, indirect light.",
                    TemperatureRangeLow = 65,
                    TemperatureRangeHigh = 75,
                    PruningInstructions = "Prune to shape as needed."
                },
                new CareInstructions
                {
                    CareInstructionsId = 2,
                    Name = "For Tropical Plants",
                    WateringInstructions = "Water sparingly.",
                    SunlightInstructions = "Bright, direct light.",
                    TemperatureRangeLow = 70,
                    TemperatureRangeHigh = 90,
                    PruningInstructions = "Prune to remove dead or damaged leaves."
                }
            );

            modelBuilder.Entity<Plant>().HasData(
                new Plant
                {
                    PlantId = 1,
                    Name = "Fiddle Leaf Fig",
                    ScientificName = "Ficus lyrata",
                    Description = "The Fiddle Leaf Fig is a popular indoor plant featuring large, violin-shaped leaves.",
                    ImageUrl = "fiddle-leaf-fig",
                    SpeciesId = 1,
                    HabitatId = 1,
                    CareInstructionsId = 1
                },
                new Plant
                {
                    PlantId = 2,
                    Name = "Swiss Cheese Plant",
                    ScientificName = "Monstera deliciosa",
                    Description = "The Swiss Cheese Plant is a tropical plant with large, glossy leaves that develop holes as they mature.",
                    ImageUrl = "SwissCheese.png",
                    SpeciesId = 2,
                    HabitatId = 1,
                    CareInstructionsId = 2
                }
            );
        }
    }
}