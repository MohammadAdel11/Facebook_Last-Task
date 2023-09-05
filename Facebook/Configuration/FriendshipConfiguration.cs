using Facebook.Tables;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace Facebook.Configuration
{
    public class FriendshipConfiguration : IEntityTypeConfiguration<FreindShip>
    {
        public void Configure(EntityTypeBuilder<FreindShip> builder)
        {
            builder.HasKey(f => f.FriendshipId);

            builder.HasOne(f => f.User)
                .WithMany(u => u.Friendships)
                .HasForeignKey(f => f.UserId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.FriendUser)
                .WithMany()
                .HasForeignKey(f => f.FriendUserId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}