using AutoMapper;
using FMECA.Application.Contracts.Persistence;
using FMECA.Application.Exceptions;
using FMECA.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
namespace FMECA.Application.Features.MetadataFMECA.Commands.Update;

public class UpdateFMECADetailsCommandHandler : IRequestHandler<UpdateFMECADetailsCommand>
{
    private readonly IFMECADetailsRepository _fmecaDetailsRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateFMECADetailsCommand> _logger;

    public UpdateFMECADetailsCommandHandler(IFMECADetailsRepository fmecaDetailsRepository, IMapper mapper, ILogger<UpdateFMECADetailsCommand> logger)
    {
        _fmecaDetailsRepository = fmecaDetailsRepository ?? throw new ArgumentNullException(nameof(fmecaDetailsRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Unit> Handle(UpdateFMECADetailsCommand request, CancellationToken cancellationToken)
    {
        var fmecaToUpdate = await _fmecaDetailsRepository.GetByIdAsync(request.FMECAId);
        if (fmecaToUpdate == null)
        {
            throw new NotFoundException(nameof(FMECADetails), request.FMECAId);
        }

        _mapper.Map(request, fmecaToUpdate, typeof(UpdateFMECADetailsCommand), typeof(FMECADetails));
        await _fmecaDetailsRepository.UpdateAsync(fmecaToUpdate);
        _logger.LogInformation($"Order {fmecaToUpdate.FMECAId} is successfully updated.");
        return Unit.Value;
    }
}
