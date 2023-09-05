namespace Facebook.Tables
{
    public class FriendRequest
    {
        public int FriendRequestId { get; set; }
        public int SenderUserId { get; set; }
        public int ReceiverUserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public User SenderUser { get; set; }
        public User ReceiverUser { get; set; }
    }
}