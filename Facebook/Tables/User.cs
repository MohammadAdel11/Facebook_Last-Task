namespace Facebook.Tables
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        public UserProfile UserProfile { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<FriendRequest> ReceivedFriendRequests { get; set; }
        public ICollection<FreindShip> Friendships { get; set; }
        public ICollection<SharedPost> SharedPosts { get; set; }
        public ActivityMetrice ActivityMetrics { get; set; }
        public ICollection<FriendRequest> SentFriendRequests { get; internal set; }
    }
}