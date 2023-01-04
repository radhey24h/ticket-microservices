using FMECA.Domain.Common;
using FMECA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMECA.Infrastructure.Persistence;

public class FMECAContext : DbContext
{
    public FMECAContext(DbContextOptions<FMECAContext> options) : base(options)
    {
    }

    public DbSet<MetadataFMECA> MetadataFMECA { get; set; }

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
