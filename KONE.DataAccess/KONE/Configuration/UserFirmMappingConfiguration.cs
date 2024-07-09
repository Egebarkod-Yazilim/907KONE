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
    public class UserFirmMappingConfiguration : IEntityTypeConfiguration<UserFirmMapping>
    {
        public void Configure(EntityTypeBuilder<UserFirmMapping> builder)
        {
            builder.Property(uf => uf.FirmId).IsRequired();
            builder.Property(uf => uf.UserId).IsRequired();


            builder.HasOne(ul => ul.Firm)
                .WithMany(u => u.UserFirmMappings)
                .HasForeignKey(ul => ul.FirmId);

            builder.HasOne(ul => ul.User)
                .WithMany(u => u.UserFirmMappings)
                .HasForeignKey(ul => ul.UserId);

            builder.ToTable(nameof(UserFirmMapping));
        }
    }
}
