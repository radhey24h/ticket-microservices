using FMECA.Application.Contracts.Persistence;
using DOMAIN=FMECA.Domain.Entities;
using FMECA.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FMECA.Infrastructure.Repositories;

public class FMECARepository: RepositoryBase<DOMAIN.FMECA>, IFMECARepository
{
    public FMECARepository(FMECAContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<DOMAIN.FMECA>> GetFMECAByUserNameAsync(string userName)
    {
        var ofmecaList = await _dbContext.FMECA
                          .Where(o => o.Owner == userName)
                          .ToListAsync();
        return ofmecaList;
    }

}
