using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.HealthRecords.Queries;
using Application.HealthRecords;
using Application.EducationDetails.Commands;
using Application.EducationDetails;
using Application.HealthRecords.Commands;

namespace API.Controllers
{
	[Route("api/health-records")]
	[ApiController]
	[AllowAnonymous] // temporarily set anonymous
	public class HealthRecordsController : BaseApiController
	{
		[HttpGet("{id}")]
		public async Task<ActionResult<HealthRecordsDto>> GetById(Guid id)
		{
			try
			{
				var query = new GetHealthRecordsRequestQuery { Id = id };
				var result = await this.Mediator.Send(query);
				if (result == null)
				{
					return NotFound($"Healthe Records with ID {id} not found.");
				}
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}


		[HttpPost]
		public async Task<ActionResult<HealthRecordsDto>> Add([FromBody] PostHealthRecordsRequestCommand command)
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
	}
}
