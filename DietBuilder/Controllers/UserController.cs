using DietBuilder.Models.User;
using DietBuilder.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace DietBuilder.Controllers
{
	public class UserController : Controller
	{
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            List<UserListItem> users = await _service.GetAllUsersAsync();
            return View(users);
        }

        [ActionName("Details")]
        public async Task<IActionResult> User(int id)
        {
            if (!ModelState.IsValid)
                return View();

            var user = await _service.GetUserById(id);

            if (user is null)
                return RedirectToAction(nameof(Index));

            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreate model)
        {
            if (!ModelState.IsValid)
                return View(ModelState);

            await _service.CreateUserAsync(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid)
                return View();

            var user = await _service.GetUserById(id);

            if (user is null)
                return RedirectToAction(nameof(Index));

            var userEdit = new UserUpdate()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email
            };

            return View(userEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdate model)
        {
            if (!ModelState.IsValid)
                return View(ModelState);

            var user = await _service.UpdateUserAsync(model);

            if (!user)
                return RedirectToAction(nameof(Index));

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return View(ModelState);

            var user = await _service.GetUserById(id);

            if (user is null)
                return RedirectToAction(nameof(Index));

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UserDetail model)
        {
            if (!ModelState.IsValid)
                return View(ModelState);

            await _service.DeleteUserAsync(model.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}
