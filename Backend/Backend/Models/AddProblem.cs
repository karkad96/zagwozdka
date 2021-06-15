using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Models.Joins;

namespace Backend.Models
{
    public class AddProblem
    {
        public int ProblemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Answer { get; set; }
        public int Difficulty { get; set; }

    }
}