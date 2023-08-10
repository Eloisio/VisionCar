using VisionCar.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace VisionCar.Infrastructure.Persistence.Configurations
{
    public class EmpresaConfigurations : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder
                .HasKey(p => p.Id);
        }
    }
}
