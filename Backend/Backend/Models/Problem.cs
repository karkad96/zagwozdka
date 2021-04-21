using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Problem
    {
        public int ProblemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Answer { get; set; }
        public int SolvedBy { get; set; }
        public string Difficulty { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Tag> Tags { get; set; }
    }

    public class Tag
    {
        public int TagId { get; set; }
        public string TagName { get; set; }

        [ForeignKey("ProblemId")]
        public int ProblemId { get; set; }
        public Problem Problem { get; set; }
    }
}
