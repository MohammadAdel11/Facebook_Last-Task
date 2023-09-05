using Facebook.Tables;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Facebook.Configuration
{
    public class SharedPostConfiguraton : IEntityTypeConfiguration<SharedPost>
    {
        public void Configure(EntityTypeBuilder<SharedPost> builder)
        {
            builder.HasKey(sp => sp.SharedPostId);

            builder.HasOne(sp => sp.User)
                .WithMany(u => u.SharedPosts)
                .HasForeignKey(sp => sp.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sp => sp.OriginalPost)
                .WithMany(p => p.SharedByUsers)
                .HasForeignKey(sp => sp.OriginalPostId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
