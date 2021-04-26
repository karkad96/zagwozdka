namespace Backend.Models.Joins
{
    public class ProblemTag
    {
        public int ProblemId { get; set; }
        public Problem Problem { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
