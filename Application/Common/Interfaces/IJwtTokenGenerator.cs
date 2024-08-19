﻿using Domain.Entities;

namespace Application.Common.Interfaces
{
	public interface IJwtTokenGenerator
	{
		string GenerateToken(ApplicationUser user);
	}
}
