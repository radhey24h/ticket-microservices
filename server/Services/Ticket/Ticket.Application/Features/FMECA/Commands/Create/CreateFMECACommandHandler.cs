using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Application.Contracts.Persistence;
using Ticket.Application.Features.FMECA.Commands.Insert;

namespace Ticket.Application.Features.FMECA.Commands.Create;

public class CreateFMECACommandHandler : IRequestHandler<CreateFMECACommand, int>
{
    private readonly IFMECARepository _fmecarepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateFMECACommandHandler> _logger;

    public CreateFMECACommandHandler(IFMECARepository fmecarepository, IMapper mapper, ILogger<CreateFMECACommandHandler> logger)
    {
        _fmecarepository = fmecarepository ?? throw new ArgumentNullException(nameof(fmecarepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<int> Handle(CreateFMECACommand request, CancellationToken cancellationToken)
    {
        var fmecaEntity=_mapper.Map<FMECA>(request);
        var newfmecaEntity= await _fmecarepository.AddAsync(fmecaEntity, cancellationToken);
        _logger.LogInformation($" New FMECA {newfmecaEntity.FMeca} is successfully created.");
    }
}
