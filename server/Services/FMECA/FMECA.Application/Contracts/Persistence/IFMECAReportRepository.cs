using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMAIN=FMECA.Domain.Entities;

namespace FMECA.Application.Contracts.Persistence;

public interface IFMECAReportRepository : IAsyncRepository<DOMAIN.FMECAReport>
{
}

