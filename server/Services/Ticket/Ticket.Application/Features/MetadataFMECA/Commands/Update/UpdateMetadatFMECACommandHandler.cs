using AutoMapper;
using FMECA.Application.Contracts.Persistence;
using FMECA.Application.Exceptions;
using FMECA.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
namespace FMECA.Application.Features.MetadataFMECA.Commands.Update;

public class UpdateMetadatFMECACommandHandler : IRequestHandler<UpdateMetadatFMECACommand>
{
    private readonly IMetadataFMECARepository _fmecaDetailsRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateMetadatFMECACommand> _logger;

    public UpdateMetadatFMECACommandHandler(IMetadataFMECARepository fmecaDetailsRepository, IMapper mapper, ILogger<UpdateMetadatFMECACommand> logger)
    {
        _fmecaDetailsRepository = fmecaDetailsRepository ?? throw new ArgumentNullException(nameof(fmecaDetailsRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Unit> Handle(UpdateMetadatFMECACommand request, CancellationToken cancellationToken)
    {
        var fmecaToUpdate = await _fmecaDetailsRepository.GetByIdAsync(request.FMECAID);
        if (fmecaToUpdate == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.MetadataFMECA), request.FMECAID);
        }

        _mapper.Map(request, fmecaToUpdate, typeof(UpdateMetadatFMECACommand), typeof(Domain.Entities.MetadataFMECA));
        await _fmecaDetailsRepository.UpdateAsync(fmecaToUpdate);
        _logger.LogInformation($"Order {fmecaToUpdate.FMECAID} is successfully updated.");
        return Unit.Value;
    }
}
