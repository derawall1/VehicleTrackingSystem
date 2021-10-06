using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleTrackingSystem.Infrastructure.Domain.Entities;

namespace VehicleTrackingSystem.Infrastructure.Domain.Configuration
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
   
            builder.HasOne(d => d.Vehicle)
                 .WithMany(p => p.Positions)
                 .HasForeignKey(d => d.VehicleId)
                 .HasConstraintName("FK_Position_Vehicle");
        }
    }
}
