namespace Facebook.Tables
{
    public class SharedPost
    {
        public int SharedPostId { get; set; }
        public int UserId { get; set; }
        public int OriginalPostId { get; set; }
        public DateTime CreatedAt { get; set; }

        public User User { get; set; }
        public Post OriginalPost { get; set; }
    }
}