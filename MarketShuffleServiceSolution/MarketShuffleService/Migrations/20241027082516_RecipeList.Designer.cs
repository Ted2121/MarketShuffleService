﻿// <auto-generated />
using System;
using MarketShuffleService.Data_Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MarketShuffleService.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241027082516_RecipeList")]
    partial class RecipeList
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MarketShuffleModels.Guild", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Difficult")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Guilds");
                });

            modelBuilder.Entity("MarketShuffleModels.Item", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Buy")
                        .HasColumnType("double");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CraftUntil")
                        .HasColumnType("int");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("OrderInCategory")
                        .HasColumnType("int");

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RelistCount")
                        .HasColumnType("int");

                    b.Property<double>("Sell")
                        .HasColumnType("double");

                    b.Property<int>("SoldCount")
                        .HasColumnType("int");

                    b.Property<string>("UseFor")
                        .IsRequired()
                        .HasColumnType("longtext");

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

            modelBuilder.Entity("MarketShuffleModels.Player", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Ap")
                        .HasColumnType("int");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Exoed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("GuildId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("Mp")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<TimeOnly>("SeenOnline")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.ToTable("Players");
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

            modelBuilder.Entity("MarketShuffleModels.RecipeList", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("RecipeLists");
                });

            modelBuilder.Entity("MarketShuffleModels.RecipeListRow", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("RecipeListId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ResourceName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("RecipeListId");

                    b.ToTable("RecipeListRows");
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

            modelBuilder.Entity("MarketShuffleModels.Player", b =>
                {
                    b.HasOne("MarketShuffleModels.Guild", "Guild")
                        .WithMany("Players")
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guild");
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

            modelBuilder.Entity("MarketShuffleModels.RecipeListRow", b =>
                {
                    b.HasOne("MarketShuffleModels.RecipeList", "RecipeList")
                        .WithMany("Rows")
                        .HasForeignKey("RecipeListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RecipeList");
                });

            modelBuilder.Entity("MarketShuffleModels.Guild", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("MarketShuffleModels.Item", b =>
                {
                    b.Navigation("Positions");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("MarketShuffleModels.RecipeList", b =>
                {
                    b.Navigation("Rows");
                });
#pragma warning restore 612, 618
        }
    }
}
