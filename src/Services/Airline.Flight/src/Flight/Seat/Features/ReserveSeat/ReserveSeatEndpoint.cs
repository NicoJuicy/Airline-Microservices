using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Flight.Seat.Features.ReserveSeat;

[Route(BaseApiPath + "/flight/reserve-seat")]
public class ReserveSeatEndpoint : BaseController
{
    [HttpPost]
    // [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(Summary = "Reserve seat", Description = "Reserve seat")]
    public async Task<ActionResult> ReserveSeat([FromBody] ReserveSeatCommand command, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(command, cancellationToken);

        return Ok(result);
    }
}
