using FMECA.Application.Features.MetadataFMECA.Queries.GetAllMetadatFMECA;
using FMECA.Application.Features.MetadataFMECAReport.Commands.Delete;
using FMECA.Application.Features.MetadataFMECAReport.Commands.Insert;
using FMECA.Application.Features.MetadataFMECAReport.Commands.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FMECA.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class MetadatFMECAReportController : ControllerBase
{
    private readonly IMediator _mediator;
    public MetadatFMECAReportController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet("{userId}", Name = "GetMetadatFMECAReport")]
    [ProducesResponseType(typeof(IEnumerable<MetadatFMECAReportDTO>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<MetadatFMECAReportDTO>>> GetMetadatFMECAReport(string userId)
    {
        var query = new GetMetadatFMECAReportQuery(userId);
        var fmeca = await _mediator.Send(query);
        if (fmeca.Count <= 0)
        {
            return NotFound();
        }
        return Ok(fmeca);
    }

    [HttpPost(Name = "CreateMetadatFMECAReport")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CreateMetadatFMECAReport([FromBody] CreateMetadatFMECAReportCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut(Name = "UpdateMetadatFMECA")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateMetadatFMECAReport([FromBody] UpdateMetadatFMECAReportCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteMetadatFMECA")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteMetadatFMECAReport(string id)
    {
        var command = new DeleteMetadatFMECAReportCommand() { FMECANumber = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
