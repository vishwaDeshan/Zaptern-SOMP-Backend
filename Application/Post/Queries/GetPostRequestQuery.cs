using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Post.Queries
{
	public class GetPostRequestQuery : IRequest<List<PostDto>> { }

	public class GetPostRequestHandler : IRequestHandler<GetPostRequestQuery, List<PostDto>>
	{
		private readonly IApplicationDbContext _applicationDbContext;

		public GetPostRequestHandler(IApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public async Task<List<PostDto>> Handle(GetPostRequestQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var posts = await _applicationDbContext.Posts
					.Select(p => new PostDto
					{
						Id = p.Id,
						Title = p.Title,
						Description = p.Description,
						Author = p.Author,
					})
					.ToListAsync(cancellationToken);

				if (posts.Count == 0)
				{
					return new List<PostDto>
					{
						new PostDto
						{
							Id = Guid.Empty,
							Title = "Default Title",
							Description = "Default Description",
							Author = "Default Author"
						}
					};
				}

				return posts;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
