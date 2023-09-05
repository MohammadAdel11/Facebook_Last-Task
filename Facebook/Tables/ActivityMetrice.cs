namespace Facebook.Tables
{
    public class ActivityMetrice
    {
        public int ActivityMetricsId { get; set; }
        public int UserId { get; set; }
        public int NumberOfPosts { get; set; }
        public int NumberOfFollowers { get; set; }
        public int NumberOfFollowing { get; set; }
        public DateTime CreatedAt { get; set; }

        public User User { get; set; }
    }
}