using KONE.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONE.DataAccess.KONE.Configuration
{
    public class UserLoginHistoryConfiguration : IEntityTypeConfiguration<UserLoginHistory>
    {
        public void Configure(EntityTypeBuilder<UserLoginHistory> builder)
        {
            builder.Property(ul => ul.IpAddress).IsRequired();
            builder.Property(ul => ul.UserId).IsRequired();
            builder.Property(ul => ul.LoginDate).IsRequired();


            builder.HasOne(ul => ul.User)
                .WithMany(u => u.UserLoginHistories)
                .HasForeignKey(ul => ul.UserId);


            builder.ToTable(nameof(UserLoginHistory));
        }
    }
}
