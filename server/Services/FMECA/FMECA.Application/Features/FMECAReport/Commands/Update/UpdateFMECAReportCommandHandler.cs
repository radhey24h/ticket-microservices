using AutoMapper;
using FMECA.Application.Contracts.Persistence;
using FMECA.Application.Exceptions;
using FMECA.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
namespace FMECA.Application.Features.FMECAReport.Commands.Update;

public class UpdateFMECAReportCommandHandler : IRequestHandler<UpdateFMECAReportCommand>
{
    private readonly IFMECAReportRepository _fmecaReportRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateFMECAReportCommand> _logger;

    public UpdateFMECAReportCommandHandler(IFMECAReportRepository fmecaReportRepository, IMapper mapper, ILogger<UpdateFMECAReportCommand> logger)
    {
        _fmecaReportRepository = fmecaReportRepository ?? throw new ArgumentNullException(nameof(fmecaReportRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Unit> Handle(UpdateFMECAReportCommand request, CancellationToken cancellationToken)
    {
        var fmecaToUpdate = await _fmecaReportRepository.GetByIdAsync(request.ID);
        if (fmecaToUpdate == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.FMECA), request.ID);
        }

        _mapper.Map(request, fmecaToUpdate, typeof(UpdateFMECAReportCommand), typeof(Domain.Entities.FMECA));
        await _fmecaReportRepository.UpdateAsync(fmecaToUpdate);
        _logger.LogInformation($"Order {fmecaToUpdate.FMECANumber} is successfully updated.");
        return Unit.Value;
    }
}
