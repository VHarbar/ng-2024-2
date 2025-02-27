using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserName)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasOne(a => a.Account)
                .WithOne(u => u.User)
                .HasForeignKey<User>(x => x.AccountId);
        }
    }
}
