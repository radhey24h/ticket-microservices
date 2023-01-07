using FMECA.Application.Features.FMECA.Queries.GetAllMetadatFMECA;
using FMECA.Application.Features.FMECA.Queries.GetDashboard;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FMECA.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CommonController : ControllerBase
{
    private readonly IMediator _mediator;
    public CommonController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    
}
