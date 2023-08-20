using VisionCar.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace VisionCar.Infrastructure.Persistence.Configurations
{
    public class VendaConfigurations : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder
                .HasKey(s => s.Id);
        }
    }
}
