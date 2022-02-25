using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Flight.Seat.Features.GetAvailableSeats;

[Route(BaseApiPath + "/flight/get-available-seats")]
public class GetAvailableSeatsEndpoint : BaseController
{
    // [Authorize]
    [HttpGet("{FlightId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(Summary = "Get available seats", Description = "Get available seats")]
    public async Task<ActionResult> GetAvailableSeats([FromRoute] GetAvailableSeatsQuery command,
        CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(command, cancellationToken);

        return Ok(result);
    }
}
