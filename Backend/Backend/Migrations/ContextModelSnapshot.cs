﻿// <auto-generated />
using System;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            ReleaseDate = new DateTime(2021, 4, 21, 18, 35, 13, 752, DateTimeKind.Local).AddTicks(7976),
                            SolvedBy = 112,
                            Title = "Problem 1"
                        },
                        new
                        {
                            ProblemId = 2,
                            Answer = "5272",
                            Description = "Test 2",
                            Difficulty = "Normalny",
                            ReleaseDate = new DateTime(2021, 4, 21, 18, 35, 13, 757, DateTimeKind.Local).AddTicks(7166),
                            SolvedBy = 52,
                            Title = "Problem 2"
                        },
                        new
                        {
                            ProblemId = 3,
                            Answer = "234677892",
                            Description = "Test 3",
                            Difficulty = "Trudny",
                            ReleaseDate = new DateTime(2021, 4, 21, 18, 35, 13, 757, DateTimeKind.Local).AddTicks(7328),
                            SolvedBy = 12,
                            Title = "Problem 3"
                        });
                });

            modelBuilder.Entity("Backend.Models.ProblemTag", b =>
                {
                    b.Property<int>("ProblemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProblemId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("ProblemTags");

                    b.HasData(
                        new
                        {
                            ProblemId = 1,
                            TagId = 1
                        },
                        new
                        {
                            ProblemId = 1,
                            TagId = 3
                        },
                        new
                        {
                            ProblemId = 1,
                            TagId = 5
                        },
                        new
                        {
                            ProblemId = 2,
                            TagId = 2
                        },
                        new
                        {
                            ProblemId = 2,
                            TagId = 4
                        },
                        new
                        {
                            ProblemId = 3,
                            TagId = 1
                        });
                });

            modelBuilder.Entity("Backend.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TagId");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            TagId = 1,
                            TagName = "Matematyka"
                        },
                        new
                        {
                            TagId = 2,
                            TagName = "Drzewo binarne"
                        },
                        new
                        {
                            TagId = 3,
                            TagName = "Programowanie"
                        },
                        new
                        {
                            TagId = 4,
                            TagName = "Fizyka"
                        },
                        new
                        {
                            TagId = 5,
                            TagName = "Programowanie Dynamiczne"
                        });
                });

            modelBuilder.Entity("Backend.Models.ProblemTag", b =>
                {
                    b.HasOne("Backend.Models.Problem", "Problem")
                        .WithMany("ProblemTags")
                        .HasForeignKey("ProblemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Tag", "Tag")
                        .WithMany("ProblemTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Problem");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Backend.Models.Problem", b =>
                {
                    b.Navigation("ProblemTags");
                });

            modelBuilder.Entity("Backend.Models.Tag", b =>
                {
                    b.Navigation("ProblemTags");
                });
#pragma warning restore 612, 618
        }
    }
}