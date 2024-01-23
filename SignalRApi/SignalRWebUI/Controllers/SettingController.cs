using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalREntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDtos;

namespace SignalRWebUI.Controllers
{
	public class SettingController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public SettingController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			UserEditDto userEditDto = new UserEditDto();
			userEditDto.Surname = user.Surname;
			userEditDto.Name = user.Name;
			userEditDto.Username = user.UserName;
			userEditDto.Mail = user.Email;

			return View(userEditDto);
		}

		[HttpPost]
		public async Task<IActionResult> Index(UserEditDto model)
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			user.Name = model.Name;
			user.Surname = model.Surname;
			user.Email = model.Mail;
			user.UserName = model.Username;
			if(model.Password != null)
			{
				user.PasswordHash = _userManager.PasswordHasher.HashPassword(user,model.Password);
			}
			await _userManager.UpdateAsync(user);

			return RedirectToAction("LogOut", "Login");
		}
	}
}
