﻿using Application.UserAccount.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Authentication
{
    public class AccountService : IAccount
	{
		private readonly HttpClient httpClient;

		public AccountService(HttpClient httpClient)
        {
			this.httpClient = httpClient;
		}
        public async Task<LoginResponse> LogInAccountAsync(LoginUserDTO model)
		{
			var response = await httpClient.PostAsJsonAsync("api/user/login", model);
			var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
			return result!;
		}

		public async Task<RegistrationResponse> RegisterAccountAsync(RegisterUserDTO model)
		{
			var response = await httpClient.PostAsJsonAsync("api/user/register", model);
			var result = await response.Content.ReadFromJsonAsync<RegistrationResponse>();
			return result!;
		}
	}
}
