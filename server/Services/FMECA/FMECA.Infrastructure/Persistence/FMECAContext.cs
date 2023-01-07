using FMECA.Domain.Common;
using FMECA.Domain.Common.Enum;
using FMECA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DOMAIN=FMECA.Domain.Entities;
namespace FMECA.Infrastructure.Persistence;

public class FMECAContext : DbContext
{
    public FMECAContext(DbContextOptions<FMECAContext> options) : base(options)
    {
    }

    public virtual DbSet<DOMAIN.FMECA> FMECA { get; set; }
    public virtual DbSet<SystemFMECA> SystemFMECA { get; set; }
    public virtual DbSet<DesignFMECA> DesignFMECA { get; set; }
    public virtual DbSet<SafteyFMECA> SafteyFMECA { get; set; }
    public virtual DbSet<ProcessFMECA> ProcessFMECA { get; set; }
    public virtual DbSet<FMECAReport> Report { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<DOMAIN.FMECA>()
           .Property(u => u.FMECAStatus)
           .HasConversion<string>()
           .HasMaxLength(200);

        modelBuilder.Entity<DOMAIN.FMECA>()
           .Property(u => u.FMECAType)
           .HasConversion<string>()
           .HasMaxLength(200);

        modelBuilder.Entity<DOMAIN.FMECA>()
           .Property(u => u.ProcessFMECAType)
           .HasConversion<string>()
           .HasMaxLength(200);

        modelBuilder.Entity<DOMAIN.FMECA>(entity =>
        {
            entity.HasMany(y => y.SystemFMECA);
            entity.HasMany(y => y.DesignFMECA);
            entity.HasMany(y => y.SafteyFMECA);
            entity.HasMany(y => y.ProcessFMECA);
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
