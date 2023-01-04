using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMECA.Domain.Entities;

namespace FMECA.Application.Contracts.Persistence;

public interface IFMECADetailsRepository : IAsyncRepository<MetadataFMECA>
{
    Task<IReadOnlyList<MetadataFMECA>> GetFMECAByUserIdAsync(string userId);
}

