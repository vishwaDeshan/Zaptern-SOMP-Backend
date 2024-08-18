using Application.Common.Interfaces;
using Application.Post;
using Application.Post.Queries;
using Application.UserAccount.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/home")]
	[ApiController]
	[AllowAnonymous]
	public class PostController : BaseApiController
	{

		[HttpGet("getPosts")]
		public async Task<List<PostDto>> Get([FromQuery] GetPostRequestQuery query)
		{
			return await this.Mediator.Send(query);
		}
	}
}
