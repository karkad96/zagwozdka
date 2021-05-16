﻿using System;
using Backend.Models;
using Backend.Models.Joins;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
	public class Context : IdentityDbContext
	{
		public DbSet<ApplicationUser> ApplicationUsers { get; set; }
		public DbSet<Problem> Problems { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<ProblemTag> ProblemTags { get; set; }
		public DbSet<ProblemUser> ProblemUsers { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<PostUser> PostUsers { get; set; }

		public Context(DbContextOptions<Context> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<ProblemTag>()
				.HasKey(pt => new {pt.ProblemId, pt.TagId});

			modelBuilder.Entity<ProblemTag>()
				.HasOne(pt => pt.Problem)
				.WithMany(p => p.ProblemTags)
				.HasForeignKey(pt => pt.ProblemId);

			modelBuilder.Entity<ProblemTag>()
				.HasOne(pt => pt.Tag)
				.WithMany(t => t.ProblemTags)
				.HasForeignKey(pt => pt.TagId);

			modelBuilder.Entity<ProblemUser>()
				.HasKey(pt => new {pt.ProblemId, pt.Id});

			modelBuilder.Entity<ProblemUser>()
				.HasOne(pt => pt.Problem)
				.WithMany(p => p.ProblemUsers)
				.HasForeignKey(pt => pt.ProblemId);

			modelBuilder.Entity<ProblemUser>()
				.HasOne(pt => pt.ApplicationUser)
				.WithMany(t => t.ProblemUsers)
				.HasForeignKey(pt => pt.Id);

			modelBuilder.Entity<Problem>()
				.HasMany(p => p.Posts)
				.WithOne(p => p.Problem)
				.HasForeignKey(p => p.ProblemId);

			modelBuilder.Entity<ApplicationUser>()
				.HasMany(au => au.Posts)
				.WithOne(p => p.ApplicationUser)
				.HasForeignKey(p => p.UserId);

			modelBuilder.Entity<PostUser>()
				.HasKey(pt => new {pt.PostId, pt.UserId});

			modelBuilder.Entity<PostUser>()
				.HasOne(pu => pu.Post)
				.WithMany(p => p.PostUsers)
				.HasForeignKey(pt => pt.PostId);

			modelBuilder.Entity<PostUser>()
				.HasOne(pu => pu.ApplicationUser)
				.WithMany(t => t.PostUsers)
				.HasForeignKey(pt => pt.UserId);

			modelBuilder.Entity<Problem>().HasData(
				new Problem
				{
					ProblemId = 1,
					Title = "Problem 1",
					Description = "Test 1",
					Answer = "128754612",
					SolvedBy = 112,
					Difficulty = "Łatwy",
					ReleaseDate = DateTime.Now
				}
			);

			modelBuilder.Entity<Problem>().HasData(
				new Problem
				{
					ProblemId = 2,
					Title = "Problem 2",
					Description = "Test 2",
					Answer = "5272",
					SolvedBy = 52,
					Difficulty = "Normalny",
					ReleaseDate = DateTime.Now
				}
			);

			modelBuilder.Entity<Problem>().HasData(
				new Problem
				{
					ProblemId = 3,
					Title = "Problem 3",
					Description = "Test 3",
					Answer = "234677892",
					SolvedBy = 12,
					Difficulty = "Trudny",
					ReleaseDate = DateTime.Now
				}
			);

			modelBuilder.Entity<Tag>().HasData(
				new Tag
				{
					TagId = 1,
					TagName = "Matematyka"
				}
			);
			modelBuilder.Entity<Tag>().HasData(
				new Tag
				{
					TagId = 2,
					TagName = "Drzewo binarne"
				}
			);
			modelBuilder.Entity<Tag>().HasData(
				new Tag
				{
					TagId = 3,
					TagName = "Programowanie"
				}
			);

			modelBuilder.Entity<Tag>().HasData(
				new Tag
				{
					TagId = 4,
					TagName = "Fizyka"
				}
			);
			modelBuilder.Entity<Tag>().HasData(
				new Tag
				{
					TagId = 5,
					TagName = "Programowanie Dynamiczne"
				}
			);

			modelBuilder.Entity<ProblemTag>().HasData(
				new ProblemTag
				{
					ProblemId = 1,
					TagId = 1
				}
			);
			modelBuilder.Entity<ProblemTag>().HasData(
				new ProblemTag
				{
					ProblemId = 1,
					TagId = 3
				}
			);
			modelBuilder.Entity<ProblemTag>().HasData(
				new ProblemTag
				{
					ProblemId = 1,
					TagId = 5
				}
			);

			modelBuilder.Entity<ProblemTag>().HasData(
				new ProblemTag
				{
					ProblemId = 2,
					TagId = 2
				}
			);
			modelBuilder.Entity<ProblemTag>().HasData(
				new ProblemTag
				{
					ProblemId = 2,
					TagId = 4
				}
			);

			modelBuilder.Entity<ProblemTag>().HasData(
				new ProblemTag
				{
					ProblemId = 3,
					TagId = 1
				}
			);
		}
	}
}
