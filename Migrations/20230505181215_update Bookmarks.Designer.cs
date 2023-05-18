﻿// <auto-generated />
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(DefaultDbContext))]
    [Migration("20230505181215_update Bookmarks")]
    partial class updateBookmarks
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Entities.Bookmark", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.ToTable("Bookmarks");
                });
#pragma warning restore 612, 618
        }
    }
}
