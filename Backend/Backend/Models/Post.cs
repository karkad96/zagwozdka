using System;
using System.Collections.Generic;
using Backend.Models.Joins;

namespace Backend.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }

        public DateTime PostDate { get; set; }

        public int ProblemId { get; set; }
        public Problem Problem { get; set; }

        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<PostUserLike> PostUserLikes { get; set; }
        public List<PostUserReport> PostUserReports { get; set; }
    }
}
