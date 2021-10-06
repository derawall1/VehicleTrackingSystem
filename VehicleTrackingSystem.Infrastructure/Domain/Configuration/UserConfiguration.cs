using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleTrackingSystem.Infrastructure.Domain.Entities;

namespace VehicleTrackingSystem.Infrastructure.Domain.Configuration
{

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.FirstName)
                .HasMaxLength(100);
            builder.Property(p => p.LastName)
             .HasMaxLength(100);
               builder.Property(p => p.Email)
             .HasMaxLength(200);
          


        }
    }
}
