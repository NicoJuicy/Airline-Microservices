using BuildingBlocks.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Passenger.Passenger.Features.GetPassengerById;

[Route(BaseApiPath + "/passengers")]
public class GetPassengerByIdEndpoint: BaseController
{
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(Summary = "Get passenger by id", Description = "Get passenger by id")]
    public async Task<ActionResult> GetById([FromRoute] GetPassengerQueryById command, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(command, cancellationToken);

        return Ok(result);
    }
}