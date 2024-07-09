using KONE.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONE.DataAccess.KONE.Configuration
{
    public class ActivityLogConfiguration : IEntityTypeConfiguration<ActivityLog>
    {
        public void Configure(EntityTypeBuilder<ActivityLog> builder)
        {
            builder.Property(ul => ul.Activity).IsRequired();
            builder.Property(ul => ul.IpAddress).IsRequired();
            builder.Property(ul => ul.UserId).IsRequired();
            builder.Property(ul => ul.CreatedDate).IsRequired();


            builder.HasOne(ul => ul.User)
                .WithMany(u => u.ActivityLogs)
                .HasForeignKey(ul => ul.UserId);


            builder.ToTable(nameof(ActivityLog));
        }
    }
}
