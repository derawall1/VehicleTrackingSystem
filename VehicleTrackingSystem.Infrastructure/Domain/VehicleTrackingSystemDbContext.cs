using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using System.Threading;
using System.Threading.Tasks;
using VehicleTrackingSystem.Infrastructure.Domain.Common;
using VehicleTrackingSystem.Infrastructure.Domain.Entities;
using VehicleTrackingSystem.Infrastructure.Repositories.Interfaces;

namespace VehicleTrackingSystem.Infrastructure.Domain
{
    public class VehicleTrackingSystemDbContext : DbContext
    {
        private readonly IContextRepository _contextRepository;

        public VehicleTrackingSystemDbContext(DbContextOptions options) : base(options)
        {
        }

        public VehicleTrackingSystemDbContext(DbContextOptions options, IContextRepository contextRepository) : base(options)
        {
            _contextRepository = contextRepository;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>()
                .Property(b => b.ExtendedData)
                 .HasConversion(
                            v => JsonConvert.SerializeObject(v),
                            v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v));

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VehicleTrackingSystemDbContext).Assembly);

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Vehicle>().ToTable("Vehicle");
            modelBuilder.Entity<Position>().ToTable("Position");
        }


        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Position> Positions { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _contextRepository.GetUserId();
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.IsActive = true;

                        break;
                    case EntityState.Modified:
                        entry.Entity.LastUpdatedBy = _contextRepository.GetUserId();
                        entry.Entity.LastUpdatedDate = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
