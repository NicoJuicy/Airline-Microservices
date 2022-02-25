using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Flight.Flight.Features.GetAvailableFlights;

[Route(BaseApiPath + "/flight/get-available-flights")]
public class GetAvailableFlightsEndpoint : BaseController
{
    // [Authorize]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(Summary = "Get available flights", Description = "Get available flights")]
    public async Task<ActionResult> GetAvailableFlights([FromRoute] GetAvailableFlightsQuery command, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(command, cancellationToken);

        return Ok(result);
    }
}
