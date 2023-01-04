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

    public async Task<IReadOnlyList<MetadataFMECA>> GetFMECAByUserNameAsync(string userName)
    {
        var ofmecaList = await _dbContext.MetadataFMECA
                          .Where(o => o.Owner == userName)
                          .ToListAsync();
        return ofmecaList;
    }

}
