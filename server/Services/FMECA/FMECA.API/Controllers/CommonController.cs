using FMECA.Application.Features.MetadataFMECA.Queries.GetAllMetadatFMECA;
using FMECA.Application.Features.MetadataFMECA.Queries.GetDashboard;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FMECA.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommonController : ControllerBase
{
    private readonly IMediator _mediator;
    public CommonController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    
}
