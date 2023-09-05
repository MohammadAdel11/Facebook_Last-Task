namespace Facebook.Tables
{
    public class UserProfile
    {
        public int UserProfileId { get; set; }
        public string Username { get; set; }
        public string ProfileImage { get; set; }
        public string Bio { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}