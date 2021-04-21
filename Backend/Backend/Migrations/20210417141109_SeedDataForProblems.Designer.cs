﻿// <auto-generated />
using System;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210417141109_SeedDataForProblems")]
    partial class SeedDataForProblems
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Backend.Models.Problem", b =>
                {
                    b.Property<int>("ProblemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Difficulty")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("SolvedBy")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ProblemId");

                    b.ToTable("Problems");

                    b.HasData(
                        new
                        {
                            ProblemId = 1,
                            Answer = "128754612",
                            Description = "Test 1",
                            Difficulty = "Łatwy",
                            ReleaseDate = new DateTime(2021, 4, 17, 16, 11, 8, 864, DateTimeKind.Local).AddTicks(4050),
                            SolvedBy = 112,
                            Title = "Problem 1"
                        },
                        new
                        {
                            ProblemId = 2,
                            Answer = "5272",
                            Description = "Test 2",
                            Difficulty = "Normalny",
                            ReleaseDate = new DateTime(2021, 4, 17, 16, 11, 8, 869, DateTimeKind.Local).AddTicks(1818),
                            SolvedBy = 52,
                            Title = "Problem 2"
                        },
                        new
                        {
                            ProblemId = 3,
                            Answer = "234677892",
                            Description = "Test 3",
                            Difficulty = "Trudny",
                            ReleaseDate = new DateTime(2021, 4, 17, 16, 11, 8, 869, DateTimeKind.Local).AddTicks(1974),
                            SolvedBy = 12,
                            Title = "Problem 3"
                        });
                });

            modelBuilder.Entity("Backend.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProblemId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TagId");

                    b.HasIndex("ProblemId");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            TagId = 1,
                            ProblemId = 1,
                            TagName = "Matematyka"
                        },
                        new
                        {
                            TagId = 2,
                            ProblemId = 1,
                            TagName = "Programowanie"
                        },
                        new
                        {
                            TagId = 3,
                            ProblemId = 2,
                            TagName = "Programowanie"
                        },
                        new
                        {
                            TagId = 4,
                            ProblemId = 2,
                            TagName = "Fizyka"
                        },
                        new
                        {
                            TagId = 5,
                            ProblemId = 3,
                            TagName = "Programowanie Dynamiczne"
                        });
                });

            modelBuilder.Entity("Backend.Models.Tag", b =>
                {
                    b.HasOne("Backend.Models.Problem", "Problem")
                        .WithMany("Tags")
                        .HasForeignKey("ProblemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Problem");
                });

            modelBuilder.Entity("Backend.Models.Problem", b =>
                {
                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
