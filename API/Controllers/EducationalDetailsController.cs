using Application.EducationDetails;
using Application.EducationDetails.Queries;
using Application.EducationDetails.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/educational-details")]
	[ApiController]
	[AllowAnonymous] // temporarily set anonymous
	public class EducationalDetailsController : BaseApiController
	{
		[HttpGet]
		public async Task<ActionResult<List<EducationalDetailsDto>>> GetAll([FromQuery] GetAllEducationalDetailsRequestQuery query)
		{
			try
			{
				var result = await this.Mediator.Send(query);
				if (result == null || result.Count == 0)
				{
					return NoContent();
				}
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<EducationalDetailsDto>> GetById(Guid id)
		{
			try
			{
				var query = new GetEducationalDetailsByIdRequestQuery { ApplicantId = id };
				var result = await this.Mediator.Send(query);
				if (result == null)
				{
					return NotFound($"Educational details with ID {id} not found.");
				}
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}

		[HttpPost]
		public async Task<ActionResult<EducationalDetailsDto>> Add([FromBody] PostEducationalDetailsRequestCommand command)
		{
			try
			{
				var result = await this.Mediator.Send(command);
				return CreatedAtAction(nameof(GetById), new { id = result.ApplicantId }, result);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			try
			{
				var command = new DeleteEducationalDetailsRequestCommand { Id = id };
				var result = await this.Mediator.Send(command);
				if (result != Guid.Empty)
				{
					return Ok(new { Message = "Educational details deleted successfully.", Id = result });
				}
				return NotFound($"Educational details with ID {id} not found.");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}
	}
}
