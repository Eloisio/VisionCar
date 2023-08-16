using VisionCar.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace VisionCar.Infrastructure.Persistence.Configurations
{
    public class ServicoConfigurations : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder
                .HasKey(p => p.Id);
        }
    }
}
