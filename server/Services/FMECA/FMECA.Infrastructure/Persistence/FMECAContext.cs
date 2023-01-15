using FMECA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DOMAIN = FMECA.Domain.Entities;
namespace FMECA.Infrastructure.Persistence;

public class FMECAContext : DbContext
{
    public FMECAContext(DbContextOptions<FMECAContext> options) : base(options)
    {
    }

    public virtual DbSet<DOMAIN.FMECA> FMECA { get; set; }
    public virtual DbSet<PartRisk> PartRisk { get; set; }
    public virtual DbSet<PartRiskColumnDefinition> PartRiskColumnDefinition { get; set; }
    
    public virtual DbSet<ProcessRisk> ProcessRisk { get; set; }
    public virtual DbSet<FMECAReport> FMECAReport { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<DOMAIN.FMECA>()
          .HasKey(x => new { x.ID, x.FMECANumber });

        modelBuilder.Entity<DOMAIN.PartRiskColumnDefinition>()
          .HasKey(x => new { x.ID, x.ColumnName, x.FMECAType });

        modelBuilder.Entity<DOMAIN.FMECA>()
           .Property(u => u.FMECAStatus)
           .HasConversion<int>()
           .IsRequired();

        modelBuilder.Entity<DOMAIN.FMECA>()
           .Property(u => u.FMECAType)
           .HasConversion<int>()
           .IsRequired();

        modelBuilder.Entity<DOMAIN.FMECA>()
           .Property(u => u.ProcessFMECAType)
           .HasConversion<int>()
           .IsRequired();

        modelBuilder.Entity<DOMAIN.FMECA>(entity =>
        {
            entity.HasMany(y => y.PartRisk);
            entity.HasMany(y => y.ProcessRisk);
        });
       
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<Audit>())
        {
            entry.Entity.DateTime = DateTime.Now;
            entry.Entity.UserId = "swn";
            break;
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
