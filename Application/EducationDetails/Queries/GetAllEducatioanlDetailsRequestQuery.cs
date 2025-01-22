using Application.Common.Interfaces;
using MediatR;

namespace Application.EducationDetails.Queries
{
	public class GetAllEducationalDetailsRequestQuery : IRequest<List<EducationalDetailsDto>>{ }

	public class GetAllEducationalRequestQueryHandler : IRequestHandler<GetAllEducationalDetailsRequestQuery, List<EducationalDetailsDto>>{

		private readonly IApplicationDbContext _applicationDbContext;

		public GetAllEducationalRequestQueryHandler(IApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}
		public Task<List<EducationalDetailsDto>> Handle(GetAllEducationalDetailsRequestQuery request, CancellationToken cancellationToken)
		{
			return null;
		}
	}
}
