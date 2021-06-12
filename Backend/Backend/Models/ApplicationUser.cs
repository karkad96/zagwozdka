using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Models.Joins;
using Microsoft.AspNetCore.Identity;

 namespace Backend.Models
{
	public class ApplicationUser: IdentityUser
	{
		public List<ProblemUser> ProblemUsers { get; set; }
		public List<Post> Posts { get; set; }
		public List<PostUserLike> PostUserLikes { get; set; }
		public List<PostUserReport> PostUserReports { get; set; }
		public string ProgramingLanguage { get; set; }
		public string ExtraInfo { get; set; }
		public string Image { get; set; }
	}
}
