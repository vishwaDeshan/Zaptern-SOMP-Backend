using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BaseApiController : ControllerBase
	{
		private ISender? _mediator;

		protected ISender? Mediator => this._mediator ??= this.HttpContext.RequestServices.GetService<ISender>();


	}
}
