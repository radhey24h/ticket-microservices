using FMECA.Application.Contracts.Persistence;
using FMECA.Infrastructure.Persistence;
using DOMAIN = FMECA.Domain.Entities;

namespace FMECA.Infrastructure.Repositories;

public class FMECAReportRepository: RepositoryBase<DOMAIN.FMECAReport>, IFMECAReportRepository
{
    public FMECAReportRepository(FMECAContext dbContext) : base(dbContext)
    {
    }

}
