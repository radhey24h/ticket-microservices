using FMECA.Application.Features.FMECAReport.Commands.Create;
using FMECA.Application.Features.FMECAReport.Commands.Delete;
using FMECA.Application.Features.FMECAReport.Commands.Update;
using FMECA.Application.Features.FMECAReport.Queries.GetFMECAReport;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FMECA.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class FMECAReportController : ControllerBase
{
    private readonly IMediator _mediator;
    public FMECAReportController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet("{userId}", Name = "GetFMECAReport")]
    [ProducesResponseType(typeof(IEnumerable<FMECAReportDTO>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<FMECAReportDTO>>> GetFMECAReport(string userId)
    {
        var query = new GetFMECAReportQuery(userId);
        var fmeca = await _mediator.Send(query);
        if (fmeca.Count <= 0)
        {
            return NotFound();
        }
        return Ok(fmeca);
    }

    [HttpPost(Name = "CreateFMECAReport")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CreateFMECAReport([FromBody] CreateFMECAReportCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut(Name = "UpdateFMECAReport")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateFMECAReport([FromBody] UpdateFMECAReportCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteFMECAReport")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteFMECAReport(int id)
    {
        var command = new DeleteFMECAReportCommand() { ID = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
