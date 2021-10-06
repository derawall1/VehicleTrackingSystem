using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleTrackingSystem.Infrastructure.Domain.Entities;

namespace VehicleTrackingSystem.Infrastructure.Domain.Configuration
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(200);




            builder.HasOne(d => d.User)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Vehicle_User");
        }
    }
}
