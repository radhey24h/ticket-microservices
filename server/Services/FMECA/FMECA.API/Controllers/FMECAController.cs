using FMECA.Application.Features.FMECA.Commands.Delete;
using FMECA.Application.Features.FMECA.Commands.Insert;
using FMECA.Application.Features.FMECA.Commands.Update;
using FMECA.Application.Features.FMECA.Queries.GetAllMetadatFMECA;
using FMECA.Application.Features.FMECA.Queries.GetDashboard;
using FMECA.Application.Features.FMECA.Queries.GetMyOpenFMECA;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FMECA.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class FMECAController : ControllerBase
{
    private readonly IMediator _mediator;
    public FMECAController(IMediator mediator)
    {
        _mediator = mediator?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet(Name = "GetDashboard")]
    [ProducesResponseType(typeof(IEnumerable<DashboardFMECADTO>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<DashboardFMECADTO>>> GetDashboard(string userId)
    {
        var query = new GetDashboardFMECAQuery(userId);
        var fmeca = await _mediator.Send(query);
        if (fmeca.Count <= 0)
        {
            return NotFound();
        }
        return Ok(fmeca);
    }

    [HttpGet("{userId}", Name= "GetMyOpenFMECA")]
    [ProducesResponseType(typeof(IEnumerable<MyOpenFMECADTO>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<MyOpenFMECADTO>>> GetMyOpenFMECA(string userId)
    {
        var query = new GetMyOpenFMECAQuery(userId);
        var fmeca = await _mediator.Send(query);
        if (fmeca.Count <= 0)
        {
            return NotFound();
        }
        return Ok(fmeca);
    }


    [HttpPost(Name = "CreateMetadatFMECA")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CreateMetadatFMECA([FromBody] CreateFMECACommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut(Name = "UpdateMetadatFMECA")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateMetadatFMECA([FromBody] UpdateFMECACommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteMetadatFMECA")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteMetadatFMECA(string id)
    {
        var command = new DeleteFMECACommand() { FMECANumber = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
