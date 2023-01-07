using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMAIN=FMECA.Domain.Entities;

namespace FMECA.Application.Contracts.Persistence;

public interface IFMECARepository : IAsyncRepository<DOMAIN.FMECA>
{
    Task<IReadOnlyList<DOMAIN.FMECA>> GetFMECAByUserNameAsync(string userName);
}

