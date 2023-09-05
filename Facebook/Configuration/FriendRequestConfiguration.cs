using Facebook.Tables;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Facebook.Configuration
{
    public class FriendRequestConfiguration : IEntityTypeConfiguration<FriendRequest>
    {
        public void Configure(EntityTypeBuilder<FriendRequest> builder)
        {
            builder.HasKey(fr => fr.FriendRequestId);

            // Configure relationships
            builder.HasOne(fr => fr.SenderUser)
                .WithMany(u => u.SentFriendRequests)
                .HasForeignKey(fr => fr.SenderUserId)
                .OnDelete(DeleteBehavior.Restrict); // Change CASCADE to RESTRICT

            builder.HasOne(fr => fr.ReceiverUser)
                .WithMany(u => u.ReceivedFriendRequests)
                .HasForeignKey(fr => fr.ReceiverUserId)
                .OnDelete(DeleteBehavior.Cascade); // Keep CASCADE if needed
        }
    }
}
