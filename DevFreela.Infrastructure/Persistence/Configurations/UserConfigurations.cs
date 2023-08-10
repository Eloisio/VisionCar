using VisionCar.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace VisionCar.Infrastructure.Persistence.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(s => s.Id);

            //builder
               // .HasMany(u => u.Skills)
                //.WithOne()
                //.HasForeignKey(u => u.IdSkill)
                //.OnDelete(DeleteBehavior.Restrict);
        }
    }
}
