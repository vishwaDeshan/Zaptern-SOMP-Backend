using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Post
{
	public class PostDto
	{
        public Guid Id { get; set; }

		public string? Title { get; set; }

		public string? Description { get; set; }

		public string? Author { get; set; }
    }
}
