using Application.Applicants.Commands;
using Application.Applicants;
using Application.EducationDetails;
using Application.EducationDetails.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.EducationDetails.Commands;

namespace API.Controllers
{
	[Route("api/educationalDetails")]
	[ApiController]
	[AllowAnonymous] // temporarily set anonymous
	public class EducationalDetailsController : BaseApiController
	{

		[HttpGet("getEducationalDetails")]
		public async Task<List<EducationalDetailsDto>> Get([FromQuery] GetAllEducationalDetailsRequestQuery query)
		{
			return await this.Mediator.Send(query);
		}

		[HttpPost("educationalDetails")]
		public async Task<ActionResult<EducationalDetailsDto>> Post(PostEducationalDetailsRequestCommand command)
		{
			try
			{
				var result = await this.Mediator.Send(command);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}
	}
}
