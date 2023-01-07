using AutoMapper;
using FMECA.Application.Contracts.Persistence;
using FMECA.Application.Exceptions;
using FMECA.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
namespace FMECA.Application.Features.FMECAReport.Commands.Delete;

public class DeleteFMECAReportCommandHandler : IRequestHandler<DeleteFMECAReportCommand>
{
    private readonly IFMECAReportRepository _fmecaDetailsReportRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<DeleteFMECAReportCommandHandler> _logger;

    public DeleteFMECAReportCommandHandler(IFMECAReportRepository fmecaReportDetailsRepository, IMapper mapper, ILogger<DeleteFMECAReportCommandHandler> logger)
    {
        _fmecaDetailsReportRepository = fmecaReportDetailsRepository ?? throw new ArgumentNullException(nameof(fmecaReportDetailsRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Unit> Handle(DeleteFMECAReportCommand request, CancellationToken cancellationToken)
    {
        var fmecaReportToDelete = await _fmecaDetailsReportRepository.GetByIdAsync(request.ID);
        if (fmecaReportToDelete == null)
        {
             throw new NotFoundException(nameof(fmecaReportToDelete), request.ID);
        }
        await _fmecaDetailsReportRepository.DeleteAsync(fmecaReportToDelete);
        _logger.LogInformation($" FMECA {fmecaReportToDelete.ReportName} is deleted successfully.");
        return Unit.Value;
    }
}