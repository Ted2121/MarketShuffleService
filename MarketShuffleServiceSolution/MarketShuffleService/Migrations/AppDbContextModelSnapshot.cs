﻿// <auto-generated />
using MarketShuffleService.Data_Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MarketShuffleService.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MarketShuffleModels.Item", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Buy")
                        .HasColumnType("double");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Sell")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("MarketShuffleModels.ItemPosition", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<long>("Date")
                        .HasColumnType("bigint");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Hundred")
                        .HasColumnType("double");

                    b.Property<double>("One")
                        .HasColumnType("double");

                    b.Property<string>("ParentItemId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Quality")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Ten")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("ParentItemId");

                    b.ToTable("ItemPositions");
                });

            modelBuilder.Entity("MarketShuffleModels.RecipeItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ParentItemId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentItemId");

                    b.ToTable("RecipeItems");
                });

            modelBuilder.Entity("MarketShuffleModels.ItemPosition", b =>
                {
                    b.HasOne("MarketShuffleModels.Item", "ParentItem")
                        .WithMany("Positions")
                        .HasForeignKey("ParentItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentItem");
                });

            modelBuilder.Entity("MarketShuffleModels.RecipeItem", b =>
                {
                    b.HasOne("MarketShuffleModels.Item", "ParentItem")
                        .WithMany("Recipe")
                        .HasForeignKey("ParentItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentItem");
                });

            modelBuilder.Entity("MarketShuffleModels.Item", b =>
                {
                    b.Navigation("Positions");

                    b.Navigation("Recipe");
                });
#pragma warning restore 612, 618
        }
    }
}
