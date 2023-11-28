using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietBuilder.Models.User;

namespace DietBuilder.Services.User
{
	public class UserService : IUserService
	{
		public Task<bool> CreateUserAsync(UserCreate model)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DeleteUserAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<UserListItem>> GetAllUsersAsync()
		{
			throw new NotImplementedException();
		}

		public Task<UserDetail> GetUserById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<bool> UpdateUserAsync(UserUpdate model)
		{
			throw new NotImplementedException();
		}
	}
}
