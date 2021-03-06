﻿// <auto-generated />
using Investips.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Investips.Persistence.Migrations
{
    [DbContext(typeof(InvestipsDbContext))]
    [Migration("20170902124847_AddLastUpdateToSecurity")]
    partial class AddLastUpdateToSecurity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Investips.Core.Models.Portfolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments")
                        .HasMaxLength(500);

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("Investips.Core.Models.PortfolioSecurity", b =>
                {
                    b.Property<int>("PortfolioId");

                    b.Property<int>("SecurityId");

                    b.HasKey("PortfolioId", "SecurityId");

                    b.HasIndex("SecurityId");

                    b.ToTable("PortfolioSecurity");
                });

            modelBuilder.Entity("Investips.Core.Models.Security", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("Securities");
                });

            modelBuilder.Entity("Investips.Core.Models.SecurityWidgetMultipointShape", b =>
                {
                    b.Property<int>("SecurityId");

                    b.Property<int>("WidgetMultipointShapeId");

                    b.HasKey("SecurityId", "WidgetMultipointShapeId");

                    b.HasIndex("WidgetMultipointShapeId");

                    b.ToTable("SecurityWidgetMultipointShape");
                });

            modelBuilder.Entity("Investips.Core.Models.SecurityWidgetShape", b =>
                {
                    b.Property<int>("SecurityId");

                    b.Property<int>("WidgetShapeId");

                    b.HasKey("SecurityId", "WidgetShapeId");

                    b.HasIndex("WidgetShapeId");

                    b.ToTable("SecurityWidgetShape");
                });

            modelBuilder.Entity("Investips.Core.Models.ShapeDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("DisableSave");

                    b.Property<bool>("DisableSelection");

                    b.Property<bool>("DisableUndo");

                    b.Property<bool>("Lock");

                    b.Property<int?>("OverridesId");

                    b.Property<string>("Shape");

                    b.Property<string>("Text");

                    b.Property<string>("ZOrder");

                    b.HasKey("Id");

                    b.HasIndex("OverridesId");

                    b.ToTable("ShapeDefinition");
                });

            modelBuilder.Entity("Investips.Core.Models.WidgetMultipointShape", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("SecurityId");

                    b.Property<int?>("ShapeDefinitionId");

                    b.HasKey("Id");

                    b.HasIndex("SecurityId");

                    b.HasIndex("ShapeDefinitionId");

                    b.ToTable("WidgetMultipointShapes");
                });

            modelBuilder.Entity("Investips.Core.Models.WidgetShape", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("SecurityId");

                    b.Property<int?>("ShapeDefinitionId");

                    b.Property<int?>("ShapePointId");

                    b.HasKey("Id");

                    b.HasIndex("SecurityId");

                    b.HasIndex("ShapeDefinitionId");

                    b.HasIndex("ShapePointId");

                    b.ToTable("WidgetShapes");
                });

            modelBuilder.Entity("Investips.Core.Models.WidgetShapeOverrides", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FontSize");

                    b.Property<string>("LineColor");

                    b.Property<int>("LineWidth");

                    b.Property<bool>("ShowLabel");

                    b.HasKey("Id");

                    b.ToTable("WidgetShapeOverrides");
                });

            modelBuilder.Entity("Investips.Core.Models.WidgetShapePoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Price");

                    b.Property<long>("Time");

                    b.Property<int?>("WidgetMultipointShapeId");

                    b.HasKey("Id");

                    b.HasIndex("WidgetMultipointShapeId");

                    b.ToTable("WidgetShapePoint");
                });

            modelBuilder.Entity("Investips.Core.Models.PortfolioSecurity", b =>
                {
                    b.HasOne("Investips.Core.Models.Portfolio", "Portfolio")
                        .WithMany("Securities")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Investips.Core.Models.Security", "Security")
                        .WithMany()
                        .HasForeignKey("SecurityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Investips.Core.Models.SecurityWidgetMultipointShape", b =>
                {
                    b.HasOne("Investips.Core.Models.Security", "Security")
                        .WithMany()
                        .HasForeignKey("SecurityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Investips.Core.Models.WidgetMultipointShape", "WidgetMultipointShape")
                        .WithMany()
                        .HasForeignKey("WidgetMultipointShapeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Investips.Core.Models.SecurityWidgetShape", b =>
                {
                    b.HasOne("Investips.Core.Models.Security", "Security")
                        .WithMany()
                        .HasForeignKey("SecurityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Investips.Core.Models.WidgetShape", "WidgetShape")
                        .WithMany()
                        .HasForeignKey("WidgetShapeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Investips.Core.Models.ShapeDefinition", b =>
                {
                    b.HasOne("Investips.Core.Models.WidgetShapeOverrides", "Overrides")
                        .WithMany()
                        .HasForeignKey("OverridesId");
                });

            modelBuilder.Entity("Investips.Core.Models.WidgetMultipointShape", b =>
                {
                    b.HasOne("Investips.Core.Models.Security")
                        .WithMany("WidgetMultipointShapes")
                        .HasForeignKey("SecurityId");

                    b.HasOne("Investips.Core.Models.ShapeDefinition", "ShapeDefinition")
                        .WithMany()
                        .HasForeignKey("ShapeDefinitionId");
                });

            modelBuilder.Entity("Investips.Core.Models.WidgetShape", b =>
                {
                    b.HasOne("Investips.Core.Models.Security")
                        .WithMany("WidgetShapes")
                        .HasForeignKey("SecurityId");

                    b.HasOne("Investips.Core.Models.ShapeDefinition", "ShapeDefinition")
                        .WithMany()
                        .HasForeignKey("ShapeDefinitionId");

                    b.HasOne("Investips.Core.Models.WidgetShapePoint", "ShapePoint")
                        .WithMany()
                        .HasForeignKey("ShapePointId");
                });

            modelBuilder.Entity("Investips.Core.Models.WidgetShapePoint", b =>
                {
                    b.HasOne("Investips.Core.Models.WidgetMultipointShape")
                        .WithMany("WidgetShapePoints")
                        .HasForeignKey("WidgetMultipointShapeId");
                });
#pragma warning restore 612, 618
        }
    }
}
