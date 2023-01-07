using AutoMapper;
using FMECA.Application.Contracts.Persistence;
using FMECA.Application.Exceptions;
using FMECA.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
namespace FMECA.Application.Features.FMECA.Commands.Update;

public class UpdateFMECACommandHandler : IRequestHandler<UpdateFMECACommand>
{
    private readonly IFMECARepository _fmecaDetailsRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateFMECACommand> _logger;

    public UpdateFMECACommandHandler(IFMECARepository fmecaDetailsRepository, IMapper mapper, ILogger<UpdateFMECACommand> logger)
    {
        _fmecaDetailsRepository = fmecaDetailsRepository ?? throw new ArgumentNullException(nameof(fmecaDetailsRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Unit> Handle(UpdateFMECACommand request, CancellationToken cancellationToken)
    {
        var fmecaToUpdate = await _fmecaDetailsRepository.GetByFMECANumberAsync(request.FMECANumber);
        if (fmecaToUpdate == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.FMECA), request.FMECANumber);
        }

        _mapper.Map(request, fmecaToUpdate, typeof(UpdateFMECACommand), typeof(Domain.Entities.FMECA));
        await _fmecaDetailsRepository.UpdateAsync(fmecaToUpdate);
        _logger.LogInformation($"Order {fmecaToUpdate.FMECANumber} is successfully updated.");
        return Unit.Value;
    }
}
