using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMECA.Domain.Entities;

namespace FMECA.Application.Contracts.Persistence;

public interface IFMECADetailsRepository : IAsyncRepository<FMECADetails>
{
    Task<IReadOnlyList<FMECADetails>> GetFMECAByUserIdAsync(string userId);
}

