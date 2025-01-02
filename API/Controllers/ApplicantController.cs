using API.Controllers;
using Application.Applicants;
using Application.Applicants.Queries;
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
	}
}


