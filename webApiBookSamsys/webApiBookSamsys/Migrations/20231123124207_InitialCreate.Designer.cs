﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webApiBookSamsys.Infrastructure.Entities;

#nullable disable

namespace webApiBookSamsys.Migrations
{
    [DbContext(typeof(BookSamsysContext))]
    [Migration("20231123124207_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("webApiBookSamsys.Infrastructure.Entities.Author", b =>
                {
                    b.Property<long>("IdAuthor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdAuthor"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar (50)");

                    b.HasKey("IdAuthor");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("webApiBookSamsys.Infrastructure.Entities.Author_Book", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IdAuthor")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.ToTable("Author_Books");
                });

            modelBuilder.Entity("webApiBookSamsys.Infrastructure.Entities.Book", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("varchar (50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar (50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.ToTable("Books");
                });
#pragma warning restore 612, 618
        }
    }
}