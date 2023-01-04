using FMECA.Application.Contracts.Persistence;
using FMECA.Domain.Entities;
using FMECA.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMECA.Infrastructure.Repositories;

public class MetadataFMECARepository: RepositoryBase<MetadataFMECA>, IMetadataFMECARepository
{
    public MetadataFMECARepository(FMECAContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<MetadataFMECA>> GetFMECAByUserIdAsync(int userName)
    {
        var ofmecaList = await _dbContext.MetadataFMECA
                            .Where(o => o.FMECAID == userName)
                            .ToListAsync();
        return ofmecaList;
    }

}
