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
    public class FirmConfiguration : IEntityTypeConfiguration<Firm>
    {
        public void Configure(EntityTypeBuilder<Firm> builder)
        {
            builder.Property(f => f.Name).IsRequired();

            builder.ToTable(nameof(Firm));
        }
    }
}
