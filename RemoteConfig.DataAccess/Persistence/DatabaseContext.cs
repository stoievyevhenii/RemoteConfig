using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using RemoteConfig.Core.Common;
using RemoteConfig.Core.Entities;
using RemoteConfig.DataAccess.Identity;
using RemoteConfig.Shared.Services;

using System.Reflection;

namespace RemoteConfig.DataAccess.Persistence
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IClaimService _claimService;

        public DatabaseContext(DbContextOptions options, IClaimService claimService) : base(options)
        {
            _claimService = claimService;
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<AppConfiguration> Configurations { get; set; }
        public DbSet<Project> Projects { get; set; }

        public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<IAuditedEntity>())
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _claimService.GetUserId();
                        entry.Entity.CreatedOn = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = _claimService.GetUserId();
                        entry.Entity.UpdatedOn = DateTime.Now;
                        break;
                }

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}