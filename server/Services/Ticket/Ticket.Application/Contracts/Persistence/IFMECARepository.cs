using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Domain.Entities;

namespace Ticket.Application.Contracts.Persistence;

public interface IFMECARepository : IAsyncRepository<FMECA>
{
    Task<IReadOnlyList<FMECA>> GetFMECAByUserIdAsync(string userId);
}

