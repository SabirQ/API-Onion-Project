using APIOnion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIOnion.Persistance.Configurations
{
    internal class PlantConfiguration : IEntityTypeConfiguration<Plant>
    {
        public void Configure(EntityTypeBuilder<Plant> builder)
        {
            builder.Property(p=>p.Name).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Desc).IsRequired().HasMaxLength(300);
            builder.Property(p => p.SKU).IsRequired().IsFixedLength().HasMaxLength(6);
            builder.Property(p => p.Price).HasColumnType("decimal(6,2)").IsRequired();
        }
    }
}
