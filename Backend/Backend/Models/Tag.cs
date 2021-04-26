using System.Collections.Generic;
using Backend.Models.Joins;

namespace Backend.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public List<ProblemTag> ProblemTags { get; set; }
    }
}
