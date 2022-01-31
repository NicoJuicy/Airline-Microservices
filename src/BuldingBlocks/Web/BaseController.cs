using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

namespace BuildingBlocks.Web
{
    [Route(BaseApiPath)]
    [ApiController]
    [ApiVersion("1.0")]
    public abstract class BaseController : ControllerBase
    {
        protected const string BaseApiPath = "api/v{version:apiVersion}";

        private IMediator _mediator;
        private IMapper _mapper;

        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetService<IMapper>();
    }
}