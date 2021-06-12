namespace Backend.Models.Joins
{
    public class PostUserLike
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int Likes { get; set; }
    }
}
