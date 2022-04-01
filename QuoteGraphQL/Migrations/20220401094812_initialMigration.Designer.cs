﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuoteGraphQL.Data;

#nullable disable

namespace QuoteGraphQL.Migrations
{
    [DbContext(typeof(QuoteOfTheDayDbContext))]
    [Migration("20220401094812_initialMigration")]
    partial class initialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QuoteGraphQL.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Inspirational"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Funny"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Dark"
                        });
                });

            modelBuilder.Entity("QuoteGraphQL.Entities.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Quotes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Dr . Seuss",
                            CategoryId = 1,
                            Text = "You’re off to great places, today is your day. Your mountain is waiting, so get on your way."
                        },
                        new
                        {
                            Id = 2,
                            Author = "Groucho Marx",
                            CategoryId = 1,
                            Text = "No one is perfect - that’s why pencils have erasers."
                        },
                        new
                        {
                            Id = 3,
                            Author = "Wolfgang Riebe",
                            CategoryId = 2,
                            Text = "Marriage is the chief cause of divorce."
                        });
                });

            modelBuilder.Entity("QuoteGraphQL.Entities.Quote", b =>
                {
                    b.HasOne("QuoteGraphQL.Entities.Category", "Category")
                        .WithMany("Quotes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("QuoteGraphQL.Entities.Category", b =>
                {
                    b.Navigation("Quotes");
                });
#pragma warning restore 612, 618
        }
    }
}
