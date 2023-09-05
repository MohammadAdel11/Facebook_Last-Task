using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Facebook.Tables;
namespace Facebook.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);

            builder.HasOne(u => u.UserProfile)
                .WithOne(up => up.User)
                .HasForeignKey<UserProfile>(up => up.UserId);

            builder.HasMany(u => u.Posts)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            builder.HasMany(u => u.Likes)
                .WithOne(l => l.User)
                .HasForeignKey(l => l.UserId);

            builder.HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

            builder.HasMany(u => u.SentFriendRequests)
                .WithOne(fr => fr.SenderUser)
                .HasForeignKey(fr => fr.SenderUserId);

            builder.HasMany(u => u.ReceivedFriendRequests)
                .WithOne(fr => fr.ReceiverUser)
                .HasForeignKey(fr => fr.ReceiverUserId);

            builder.HasMany(u => u.Friendships)
                .WithOne(f => f.User)
                .HasForeignKey(f => f.UserId);

            builder.HasMany(u => u.SharedPosts)
                .WithOne(sp => sp.User)
                .HasForeignKey(sp => sp.UserId);

            builder.HasOne(u => u.ActivityMetrics)
                .WithOne(am => am.User)
                .HasForeignKey<ActivityMetrice>(am => am.UserId);
        }
    }
}