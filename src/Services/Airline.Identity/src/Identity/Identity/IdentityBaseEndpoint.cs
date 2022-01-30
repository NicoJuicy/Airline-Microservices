using BuildingBlocks.Web;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Identity;

[ApiExplorerSettings(GroupName = "Identity Endpoints")]
[ApiVersion("1.0")]
[Route(BaseApiPath + "/identity")]
public abstract class IdentityBaseEndpoint : BaseController
{
}