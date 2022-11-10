using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WEB_053502_KHARLAP.Entities;

namespace WEB_053502_KHARLAP.Controllers
{
    public class ImageController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private IWebHostEnvironment _env;

        public ImageController(UserManager<ApplicationUser> userManager, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _env = env;
        }

        public async Task<FileResult> GetAvatar()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.Image != null)
                return File(user.Image, "image/...");
            else
            {
                var avatarPath = "/images/avatar.jpg";
                return File(_env.WebRootFileProvider
                    .GetFileInfo(avatarPath)
                    .CreateReadStream(), "image/...");
            }
        }
    }
}
