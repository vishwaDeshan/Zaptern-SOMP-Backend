using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EducationDetails.Commands
{
	public class DeleteEducationalDetailsRequestCommand : IRequest<Guid>
	{
		public Guid Id { get; set; }
	}

	public class DeleteEducationalDetailsRequestHandler : IRequestHandler<DeleteEducationalDetailsRequestCommand, Guid>
	{
		private readonly IApplicationDbContext _applicationDbContext;
		public DeleteEducationalDetailsRequestHandler(IApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}
		public async Task<Guid> Handle(DeleteEducationalDetailsRequestCommand request, CancellationToken cancellationToken)
		{
			try
			{
				ArgumentNullException.ThrowIfNull(request);

				var educationalDetail = await _applicationDbContext.EducationalDetails
					.FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

				if (educationalDetail == null)
				{
					throw new Exception("Educational detail not found.");
				}

				_applicationDbContext.EducationalDetails.Remove(educationalDetail);
				await _applicationDbContext.SaveChangesAsync(cancellationToken);

				return educationalDetail.Id;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
