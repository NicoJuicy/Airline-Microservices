using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Flight.Flight.Features.CreateFlight;


[Route(BaseApiPath + "/create-flight")]
public class CreateFlightEndpoint: BaseController
{
    [HttpPost(nameof(CreateFlight))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(Summary = "Create new flight", Description = "Create new flight")]
    public async Task<ActionResult> CreateFlight([FromBody] CreateFlightCommand command, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(command, cancellationToken);

        return Ok(result);
    }
}