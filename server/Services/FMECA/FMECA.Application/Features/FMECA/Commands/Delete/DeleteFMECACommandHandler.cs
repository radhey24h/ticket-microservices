using AutoMapper;
using FMECA.Application.Contracts.Persistence;
using FMECA.Application.Exceptions;
using FMECA.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
namespace FMECA.Application.Features.FMECA.Commands.Delete;

public class DeleteFMECACommandHandler : IRequestHandler<DeleteFMECACommand>
{
    private readonly IFMECARepository _fmecaDetailsRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<DeleteFMECACommandHandler> _logger;

    public DeleteFMECACommandHandler(IFMECARepository fmecaDetailsRepository, IMapper mapper, ILogger<DeleteFMECACommandHandler> logger)
    {
        _fmecaDetailsRepository = fmecaDetailsRepository ?? throw new ArgumentNullException(nameof(fmecaDetailsRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Unit> Handle(DeleteFMECACommand request, CancellationToken cancellationToken)
    {
        var fmecaToDelete = await _fmecaDetailsRepository.GetByFMECANumberAsync(request.FMECANumber);
        if (fmecaToDelete == null)
        {
             throw new NotFoundException(nameof(fmecaToDelete), request.FMECANumber);
        }
        await _fmecaDetailsRepository.DeleteAsync(fmecaToDelete);
        _logger.LogInformation($" FMECA {fmecaToDelete.FMECANumber} is deleted successfully.");
        return Unit.Value;
    }
}