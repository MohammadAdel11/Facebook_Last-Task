namespace Facebook.Tables
{
    public class FreindShip
    {
        public int FriendshipId { get; set; }
        public int UserId { get; set; }
        public int FriendUserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public User User { get; set; }
        public User FriendUser { get; set; }
    }
}