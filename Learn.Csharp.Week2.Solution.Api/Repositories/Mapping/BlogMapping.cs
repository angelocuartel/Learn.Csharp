using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Learn.Csharp.Week2.Solution.Api.Domain;

namespace Learn.Csharp.Week2.Solution.Api.Domain.Mapping
{
    public class BlogMapping : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(b => b.BlogId);

            builder.ToTable("Blog");

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(b => b.Content)
                .IsRequired();

            builder.Property(b => b.DateCreated)
                .IsRequired();

            builder.HasOne(b => b.User)
                .WithMany(u => u.Blogs)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
