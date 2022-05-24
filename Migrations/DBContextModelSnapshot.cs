﻿// <auto-generated />
using System;
using CQRS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CQRS.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CategoryEvent", b =>
                {
                    b.Property<int>("CategoriesID")
                        .HasColumnType("int");

                    b.Property<int>("EventsID")
                        .HasColumnType("int");

                    b.HasKey("CategoriesID", "EventsID");

                    b.HasIndex("EventsID");

                    b.ToTable("CategoryEvent", "dbo");
                });

            modelBuilder.Entity("CQRS.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category", "dbo");
                });

            modelBuilder.Entity("CQRS.Models.Event", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArabicTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CoverPhotoID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EnglishTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhotoAlbumID")
                        .HasColumnType("int");

                    b.Property<int>("SourceID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("CoverPhotoID");

                    b.HasIndex("PhotoAlbumID");

                    b.HasIndex("SourceID");

                    b.ToTable("Event", "dbo");
                });

            modelBuilder.Entity("CQRS.Models.Photo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("PhotoAlbumID")
                        .HasColumnType("int");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("PhotoAlbumID");

                    b.ToTable("Photo", "dbo");
                });

            modelBuilder.Entity("CQRS.Models.PhotoAlbum", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("PhotoAlbum", "dbo");
                });

            modelBuilder.Entity("CQRS.Models.Source", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Source", "dbo");
                });

            modelBuilder.Entity("CategoryEvent", b =>
                {
                    b.HasOne("CQRS.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CQRS.Models.Event", null)
                        .WithMany()
                        .HasForeignKey("EventsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CQRS.Models.Event", b =>
                {
                    b.HasOne("CQRS.Models.Photo", "CoverPhoto")
                        .WithMany()
                        .HasForeignKey("CoverPhotoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CQRS.Models.PhotoAlbum", "PhotoAlbum")
                        .WithMany()
                        .HasForeignKey("PhotoAlbumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CQRS.Models.Source", "Source")
                        .WithMany()
                        .HasForeignKey("SourceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CoverPhoto");

                    b.Navigation("PhotoAlbum");

                    b.Navigation("Source");
                });

            modelBuilder.Entity("CQRS.Models.Photo", b =>
                {
                    b.HasOne("CQRS.Models.PhotoAlbum", null)
                        .WithMany("Photos")
                        .HasForeignKey("PhotoAlbumID");
                });

            modelBuilder.Entity("CQRS.Models.PhotoAlbum", b =>
                {
                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}