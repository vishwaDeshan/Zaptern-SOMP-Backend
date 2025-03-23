using Application.Applicants;
using Application.Applicants.Commands;
using Application.Applicants.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/applicant")]
	[ApiController]
	[AllowAnonymous] // temporarily set anonymous
	public class ApplicantController : BaseApiController
	{

		[HttpGet("getApplicants")]
		public async Task<List<ApplicantDto>> Get([FromQuery] GetAllApplicantRequestQuery query)
		{
			return await this.Mediator.Send(query);
		}

		[HttpGet("getApplicant")]
		public async Task<ApplicantDto> Get([FromQuery] GetApplicantByIdRequestQuery query)
		{
			return await this.Mediator.Send(query);
		}

		[HttpPut("updateApplicant")]
		public async Task<IActionResult> Update(UpdateApplicantRequestCommand command)
		{
			try
			{
				var result = await Mediator.Send(command);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(new { error = ex.Message });
			}
		}

		[HttpPost("applicant")]
		public async Task<ActionResult<ApplicantDto>> Post(PostApplicantRequestCommand command)
		{
			try
			{
				var result = await Mediator.Send(command);
				return CreatedAtAction(nameof(Post), new { id = result.ApplicantId }, result);
			}
			catch (Exception ex)
			{
				return BadRequest(new { error = ex.Message });
			}
		}

		[HttpGet("searchApplicant")]
		public async Task<IActionResult> SearchApplicants([FromQuery] string searchTerm = "", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
		{
			var result = await Mediator.Send(new SearchApplicantsRequestQuery(searchTerm, pageNumber, pageSize));
			return Ok(result);
		}
	}
}


