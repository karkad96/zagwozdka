using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.Joins
{
    public class ProblemUser
    {
        public int ProblemId { get; set; }
        public Problem Problem { get; set; }
        public string Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
