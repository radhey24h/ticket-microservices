using AutoMapper;
using FMECA.Application.Contracts.Persistence;
using FMECA.Application.Exceptions;
using FMECA.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
namespace FMECA.Application.Features.MetadataFMECA.Commands.Delete;

public class DeleteFMECADetailsCommandHandler : IRequestHandler<DeleteFMECADetailsCommand>
{
    private readonly IFMECADetailsRepository _fmecaDetailsRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<DeleteFMECADetailsCommandHandler> _logger;

    public DeleteFMECADetailsCommandHandler(IFMECADetailsRepository fmecaDetailsRepository, IMapper mapper, ILogger<DeleteFMECADetailsCommandHandler> logger)
    {
        _fmecaDetailsRepository = fmecaDetailsRepository ?? throw new ArgumentNullException(nameof(fmecaDetailsRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Unit> Handle(DeleteFMECADetailsCommand request, CancellationToken cancellationToken)
    {
        var fmecaToDelete = await _fmecaDetailsRepository.GetByIdAsync(request.FMECAId);
        if (fmecaToDelete == null)
        {
             throw new NotFoundException(nameof(fmecaToDelete), request.FMECAId);
        }
        await _fmecaDetailsRepository.DeleteAsync(fmecaToDelete);
        _logger.LogInformation($" FMECA {fmecaToDelete.FMECAId} is deleted successfully.");
        return Unit.Value;
    }
}