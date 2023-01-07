using DOMAIN = FMECA.Domain.Entities;

namespace FMECA.Application.Contracts.Persistence;

public interface IFMECAReportRepository : IAsyncRepository<DOMAIN.FMECAReport>
{
}

