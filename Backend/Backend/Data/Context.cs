using System;
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
		public DbSet<PostUserLike> PostUserLikes { get; set; }
		public DbSet<PostUserReport> PostUserReports { get; set; }

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

			modelBuilder.Entity<PostUserLike>()
				.HasKey(pt => new {pt.PostId, pt.UserId});

			modelBuilder.Entity<PostUserLike>()
				.HasOne(pu => pu.Post)
				.WithMany(p => p.PostUserLikes)
				.HasForeignKey(pt => pt.PostId);

			modelBuilder.Entity<PostUserLike>()
				.HasOne(pu => pu.ApplicationUser)
				.WithMany(t => t.PostUserLikes)
				.HasForeignKey(pt => pt.UserId);

			modelBuilder.Entity<PostUserReport>()
				.HasKey(pt => new {pt.PostId, pt.UserId});

			modelBuilder.Entity<PostUserReport>()
				.HasOne(pu => pu.Post)
				.WithMany(p => p.PostUserReports)
				.HasForeignKey(pt => pt.PostId);

			modelBuilder.Entity<PostUserReport>()
				.HasOne(pu => pu.ApplicationUser)
				.WithMany(t => t.PostUserReports)
				.HasForeignKey(pt => pt.UserId);

			modelBuilder.Entity<ProblemUser>()
				.Property(pu => pu.SolvedDate)
				.HasDefaultValue(null);

			//Seeder.Seed(modelBuilder);
		}
	}
}
