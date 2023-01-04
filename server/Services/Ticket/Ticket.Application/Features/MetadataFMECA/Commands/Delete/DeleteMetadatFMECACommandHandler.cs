using AutoMapper;
using FMECA.Application.Contracts.Persistence;
using FMECA.Application.Exceptions;
using FMECA.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
namespace FMECA.Application.Features.MetadataFMECA.Commands.Delete;

public class DeleteMetadatFMECACommandHandler : IRequestHandler<DeleteMetadatFMECACommand>
{
    private readonly IMetadataFMECARepository _fmecaDetailsRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<DeleteMetadatFMECACommandHandler> _logger;

    public DeleteMetadatFMECACommandHandler(IMetadataFMECARepository fmecaDetailsRepository, IMapper mapper, ILogger<DeleteMetadatFMECACommandHandler> logger)
    {
        _fmecaDetailsRepository = fmecaDetailsRepository ?? throw new ArgumentNullException(nameof(fmecaDetailsRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Unit> Handle(DeleteMetadatFMECACommand request, CancellationToken cancellationToken)
    {
        var fmecaToDelete = await _fmecaDetailsRepository.GetByIdAsync(request.FMECAID);
        if (fmecaToDelete == null)
        {
             throw new NotFoundException(nameof(fmecaToDelete), request.FMECAID);
        }
        await _fmecaDetailsRepository.DeleteAsync(fmecaToDelete);
        _logger.LogInformation($" FMECA {fmecaToDelete.FMECAID} is deleted successfully.");
        return Unit.Value;
    }
}