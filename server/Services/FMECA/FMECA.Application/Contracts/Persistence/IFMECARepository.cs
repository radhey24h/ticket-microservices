using Entity = FMECA.Domain.Entities;

namespace FMECA.Application.Contracts.Persistence;

public interface IFMECARepository : IAsyncRepository<Entity.FMECA>
{
    Task<IReadOnlyList<Entity.FMECA>> GetFMECAByUserNameAsync(string userName);
}

