using Core.Domain.Constants;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Configuration
{
    internal class GlobalSettingConfiguration : IEntityTypeConfiguration<GlobalSetting>
    {
        public void Configure(EntityTypeBuilder<GlobalSetting> builder)
        {
            builder.ToTable(TableNameConstant.GlobalSettingTable);
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Type);
            builder.Property(x => x.Detail).IsRequired();
        }
    }
}
