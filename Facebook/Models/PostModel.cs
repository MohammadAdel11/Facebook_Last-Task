namespace Facebook.Models
{
    public class PostModel
    {
        public string username { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public int NumberOfLikes { get; set; }
        public int NumberOfComments { get; set; }
        public int NumberOfShares { get; set; }
        public List<string> Comments { get; set; }
    }
}
