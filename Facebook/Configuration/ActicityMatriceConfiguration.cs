using Facebook.Tables;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace Facebook.Configuration
{
    public class ActicityMatriceConfiguration : IEntityTypeConfiguration<ActivityMetrice>
    {
        public void Configure(EntityTypeBuilder<ActivityMetrice> builder)
        {
            builder.HasKey(am => am.ActivityMetricsId);

            builder.HasOne(am => am.User)
                .WithOne(u => u.ActivityMetrics)
                .HasForeignKey<ActivityMetrice>(am => am.UserId);
        }
    }
}