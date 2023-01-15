using FMECA.Application.Contracts.Persistence;
using FMECA.Domain.Entities;
using FMECA.Infrastructure.Persistence;

namespace FMECA.Infrastructure.Repositories;

public class FMECAReportRepository: RepositoryBase<FMECAReport>, IFMECAReportRepository
{
    public FMECAReportRepository(FMECAContext dbContext) : base(dbContext)
    {
    }

}
