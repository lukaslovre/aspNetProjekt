﻿// <auto-generated />
using Botanio_MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Botanio_MVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240614073201_AddRequiredAndNullable")]
    partial class AddRequiredAndNullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Botanio_MVC.Models.Domain.CareInstructions", b =>
                {
                    b.Property<int>("CareInstructionsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CareInstructionsId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PruningInstructions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SunlightInstructions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TemperatureRangeHigh")
                        .HasColumnType("int");

                    b.Property<int>("TemperatureRangeLow")
                        .HasColumnType("int");

                    b.Property<string>("WateringInstructions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CareInstructionsId");

                    b.ToTable("CareInstructions");

                    b.HasData(
                        new
                        {
                            CareInstructionsId = 1,
                            Name = "Basic Care Instructions",
                            PruningInstructions = "Prune to shape as needed.",
                            SunlightInstructions = "Bright, indirect light.",
                            TemperatureRangeHigh = 75,
                            TemperatureRangeLow = 65,
                            WateringInstructions = "Water when the top inch of soil is dry."
                        },
                        new
                        {
                            CareInstructionsId = 2,
                            Name = "For Tropical Plants",
                            PruningInstructions = "Prune to remove dead or damaged leaves.",
                            SunlightInstructions = "Bright, direct light.",
                            TemperatureRangeHigh = 90,
                            TemperatureRangeLow = 70,
                            WateringInstructions = "Water sparingly."
                        });
                });

            modelBuilder.Entity("Botanio_MVC.Models.Domain.Habitat", b =>
                {
                    b.Property<int>("HabitatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HabitatId"));

                    b.Property<string>("Climate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoilType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HabitatId");

                    b.ToTable("Habitats");

                    b.HasData(
                        new
                        {
                            HabitatId = 1,
                            Climate = "Tropical",
                            Location = "Near the equator",
                            Name = "Tropical Rainforest",
                            SoilType = "Rich, well-draining"
                        },
                        new
                        {
                            HabitatId = 2,
                            Climate = "Arid",
                            Location = "Hot and dry",
                            Name = "Desert",
                            SoilType = "Sandy"
                        });
                });

            modelBuilder.Entity("Botanio_MVC.Models.Domain.Plant", b =>
                {
                    b.Property<int>("PlantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlantId"));

                    b.Property<int>("CareInstructionsId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HabitatId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScientificName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpeciesId")
                        .HasColumnType("int");

                    b.HasKey("PlantId");

                    b.HasIndex("CareInstructionsId");

                    b.HasIndex("HabitatId");

                    b.HasIndex("SpeciesId");

                    b.ToTable("Plants");

                    b.HasData(
                        new
                        {
                            PlantId = 1,
                            CareInstructionsId = 1,
                            Description = "The Fiddle Leaf Fig is a popular indoor plant featuring large, violin-shaped leaves.",
                            HabitatId = 1,
                            ImageUrl = "fiddle-leaf-fig.webp",
                            Name = "Fiddle Leaf Fig",
                            ScientificName = "Ficus lyrata",
                            SpeciesId = 1
                        },
                        new
                        {
                            PlantId = 2,
                            CareInstructionsId = 2,
                            Description = "The Swiss Cheese Plant is a tropical plant with large, glossy leaves that develop holes as they mature.",
                            HabitatId = 1,
                            ImageUrl = "SwissCheese.png",
                            Name = "Swiss Cheese Plant",
                            ScientificName = "Monstera deliciosa",
                            SpeciesId = 2
                        });
                });

            modelBuilder.Entity("Botanio_MVC.Models.Domain.Species", b =>
                {
                    b.Property<int>("SpeciesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpeciesId"));

                    b.Property<string>("CommonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScientificName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpeciesId");

                    b.ToTable("Species");

                    b.HasData(
                        new
                        {
                            SpeciesId = 1,
                            CommonName = "Fiddle Leaf Fig",
                            Description = "The Fiddle Leaf Fig is a popular indoor plant featuring large, violin-shaped leaves.",
                            Origin = "West Africa",
                            ScientificName = "Ficus lyrata"
                        },
                        new
                        {
                            SpeciesId = 2,
                            CommonName = "Swiss Cheese Plant",
                            Description = "The Swiss Cheese Plant is a tropical plant with large, glossy leaves that develop holes as they mature.",
                            Origin = "Central America",
                            ScientificName = "Monstera deliciosa"
                        });
                });

            modelBuilder.Entity("Botanio_MVC.Models.Domain.Plant", b =>
                {
                    b.HasOne("Botanio_MVC.Models.Domain.CareInstructions", "CareInstructions")
                        .WithMany()
                        .HasForeignKey("CareInstructionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Botanio_MVC.Models.Domain.Habitat", "Habitat")
                        .WithMany()
                        .HasForeignKey("HabitatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Botanio_MVC.Models.Domain.Species", "Species")
                        .WithMany()
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CareInstructions");

                    b.Navigation("Habitat");

                    b.Navigation("Species");
                });
#pragma warning restore 612, 618
        }
    }
}
