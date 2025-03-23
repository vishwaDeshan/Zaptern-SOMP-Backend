using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Applicants.Queries
{
	public class SearchApplicantsRequestQuery : IRequest<PaginatedResult<ApplicantDto>>
	{
		public string SearchTerm { get; }
		public int PageNumber { get; }
		public int PageSize { get; }
		public ApplicantSortField SortField { get; }
		public SortOrder SortOrder { get; }

		public SearchApplicantsRequestQuery(string searchTerm, int pageNumber, int pageSize,
											 ApplicantSortField sortField, SortOrder sortOrder)
		{
			SearchTerm = searchTerm;
			PageNumber = pageNumber;
			PageSize = pageSize;
			SortField = sortField;
			SortOrder = sortOrder;
		}
	}

	public class SearchApplicantListRequestHandler : IRequestHandler<SearchApplicantsRequestQuery, PaginatedResult<ApplicantDto>>
	{
		private readonly IApplicationDbContext _applicationDbContext;
		public SearchApplicantListRequestHandler(IApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}
		public async Task<PaginatedResult<ApplicantDto>> Handle(SearchApplicantsRequestQuery request, CancellationToken cancellationToken)
		{
			ArgumentNullException.ThrowIfNull(request);
			ArgumentNullException.ThrowIfNull(_applicationDbContext, nameof(_applicationDbContext));

			string searchTerm = request.SearchTerm;
			int pageNumber = request.PageNumber;
			int pageSize = request.PageSize;

			var query = _applicationDbContext.Applicants.AsNoTracking()
					.Where(a => string.IsNullOrWhiteSpace(request.SearchTerm) ||
								EF.Functions.Like(a.FirstName, "%" + request.SearchTerm + "%") ||
								EF.Functions.Like(a.LastName, "%" + request.SearchTerm + "%") ||
								EF.Functions.Like(a.Email, "%" + request.SearchTerm + "%") ||
								EF.Functions.Like(a.City, "%" + request.SearchTerm + "%") );

			// Sorting logic based on the requested sort field and order
			query = request.SortField switch
			{
				ApplicantSortField.FirstName => request.SortOrder == SortOrder.Ascending
												? query.OrderBy(a => a.FirstName)
												: query.OrderByDescending(a => a.FirstName),
				ApplicantSortField.LastName => request.SortOrder == SortOrder.Ascending
												? query.OrderBy(a => a.LastName)
												: query.OrderByDescending(a => a.LastName),
				ApplicantSortField.Email => request.SortOrder == SortOrder.Ascending
											 ? query.OrderBy(a => a.Email)
											 : query.OrderByDescending(a => a.Email),
				ApplicantSortField.City => request.SortOrder == SortOrder.Ascending
											? query.OrderBy(a => a.City)
											: query.OrderByDescending(a => a.City),
				ApplicantSortField.DateOfBirth => request.SortOrder == SortOrder.Ascending
												  ? query.OrderBy(a => a.DateOfBirth)
												  : query.OrderByDescending(a => a.DateOfBirth),
				_ => query.OrderBy(a => a.ApplicantId)
			};


			int totalItems = await query.CountAsync(cancellationToken);

			var applicants = await query
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.Select(a => new ApplicantDto
				{
					ApplicantId = a.ApplicantId,
					PhoneNumber = a.PhoneNumber,
					LandLine = a.LandLine,
					NationalId = a.NationalId,
					City = a.City,
					FirstName = a.FirstName,
					LastName = a.LastName,
					Email = a.Email,
					DateOfBirth = a.DateOfBirth,

				}).ToListAsync(cancellationToken);

			return new PaginatedResult<ApplicantDto>(applicants, totalItems, pageNumber, pageSize);
		}
	}
}
