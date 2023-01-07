using FMECA.Application.Features.FMECA.Queries.GetAllMetadatFMECA;
using FMECA.Application.Features.FMECAReport.Commands.Delete;
using FMECA.Application.Features.FMECAReport.Commands.Insert;
using FMECA.Application.Features.FMECAReport.Commands.Update;
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

    [HttpGet("{userId}", Name = "GetMetadatFMECAReport")]
    [ProducesResponseType(typeof(IEnumerable<FMECAReportDTO>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<FMECAReportDTO>>> GetMetadatFMECAReport(string userId)
    {
        var query = new GetFMECAReportQuery(userId);
        var fmeca = await _mediator.Send(query);
        if (fmeca.Count <= 0)
        {
            return NotFound();
        }
        return Ok(fmeca);
    }

    [HttpPost(Name = "CreateMetadatFMECAReport")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CreateMetadatFMECAReport([FromBody] CreateFMECAReportCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut(Name = "UpdateMetadatFMECAReport")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateMetadatFMECAReport([FromBody] UpdateFMECAReportCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteMetadatFMECAReport")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteMetadatFMECAReport(string id)
    {
        var command = new DeleteFMECAReportCommand() { FMECANumber = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
