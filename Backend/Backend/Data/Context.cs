using System;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
	public class Context:DbContext
	{
		public DbSet<Problem> Problems { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public Context(DbContextOptions<Context> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Tag>()
				.HasOne(p => p.Problem)
				.WithMany(t => t.Tags);

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
					TagName = "Matematyka",
					ProblemId = 1
				}
			);
			modelBuilder.Entity<Tag>().HasData(
				new Tag
				{
					TagId = 2,
					TagName = "Programowanie",
					ProblemId = 1
				}
			);
			modelBuilder.Entity<Tag>().HasData(
				new Tag
				{
					TagId = 3,
					TagName = "Programowanie",
					ProblemId = 2
				}
			);
			modelBuilder.Entity<Tag>().HasData(
				new Tag
				{
					TagId = 4,
					TagName = "Fizyka",
					ProblemId = 2
				}
			);
			modelBuilder.Entity<Tag>().HasData(
				new Tag
				{
					TagId = 5,
					TagName = "Programowanie Dynamiczne",
					ProblemId = 3
				}
			);
		}
	}
}
