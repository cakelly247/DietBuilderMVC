using DietBuilder.Data;
using DietBuilder.Data.Entities;
using DietBuilder.Models.Recipe;
using DietBuilder.Models.RecipeIngredient;
using DietBuilder.Models.User;
using Microsoft.EntityFrameworkCore;

namespace DietBuilder.Services.User
{
	public class UserService : IUserService
	{
		private readonly DietBuilderDbContext _context;

        public UserService(DietBuilderDbContext context)
        {
			_context = context;
        }

        public async Task<bool> CreateUserAsync(UserCreate model)
		{
            var user = new UserEntity()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email
            };

            _context.Users.Add(user);
            return await _context.SaveChangesAsync() == 1;
        }

		public async Task<bool> DeleteUserAsync(int id)
		{
            var user = await _context.Users.FindAsync(id);

            if (user is null)
                return false;

            _context.Users.Remove(user);
            return await _context.SaveChangesAsync() == 1;
        }

		public async Task<List<UserListItem>> GetAllUsersAsync()
		{
            var users = await _context.Users
            .Select(u => new UserListItem()
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email
            }).ToListAsync();

            return users;
        }

		public async Task<UserDetail?> GetUserById(int id)
		{
            var user = await _context.Users.FindAsync(id);

            if (user is null)
                return null;

            return new UserDetail()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }

		public async Task<bool> UpdateUserAsync(UserUpdate model)
		{
            var user = await _context.Users.FindAsync(model.Id);

            if (user is null)
                return false;

            user.Id = model.Id;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;

            return await _context.SaveChangesAsync() == 1;
        }
	}
}
