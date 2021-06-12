using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Models.Joins;

namespace Backend.Models
{
    public class Problem
    {
        public int ProblemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Answer { get; set; }
        public int SolvedBy { get; set; }
        public int Difficulty { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<ProblemTag> ProblemTags { get; set; }
        public List<ProblemUser> ProblemUsers { get; set; }
        public List<Post> Posts { get; set; }
    }
}
