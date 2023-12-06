using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietBuilder.Models.Ingredient;
using DietBuilder.Models.User;

namespace DietBuilder.Services.User
{
	public interface IUserService
	{
		Task<bool> CreateUserAsync(UserCreate model);

		Task<List<UserListItem>> GetAllUsersAsync();

		Task<UserDetail?> GetUserById(int id);

		Task<bool> UpdateUserAsync(UserUpdate model);

		Task<bool> DeleteUserAsync(int id);
	}
}
