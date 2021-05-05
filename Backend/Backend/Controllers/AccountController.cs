using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Backend.Models.Joins;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Context _context;
        private readonly ILogger<AccountController> _logger;
        private readonly string _image;

        public AccountController(UserManager<ApplicationUser> userManager, Context context, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
            var b = System.IO.File.ReadAllBytes("../Backend/Data/Images/blank.png");
            _image = Convert.ToBase64String(b, 0, b.Length);
        }

        [HttpGet]
        [Authorize]
        public async Task<object> GetAccount()
        {
            var userId = User.Claims.First(claim => claim.Type == "UserID").Value;
            var image = await _context.ApplicationUsers
                .Where(u => u.Id == userId)
                .Select(u => u.Image)
                .SingleOrDefaultAsync() ?? _image;
            var details = await _context.ApplicationUsers
                .Where(u => u.Id == userId)
                .Select(u => new
                {
                    userName = u.UserName,
                    email = u.Email,
                    programmingLanguage = u.ProgramingLanguage,
                    extraInfo = u.ExtraInfo,
                    image
                }).SingleOrDefaultAsync();

            return Ok(details);
        }

        [HttpPost]
        [Authorize]
        public async Task<object> PostImage(Image image)
        {
            var userId = User.Claims.First(claim => claim.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                user.Image = image.Base64Image;
                await _userManager.UpdateAsync(user);
            }

            return Ok(HttpStatusCode.OK);
        }

        [HttpPut]
        [Authorize]
        [Route("BasicInfo")]
        public async Task<object> PutBasicInfo(BasicInfo model)
        {
            var userId = User.Claims.First(claim => claim.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                user.UserName = model.UserName;
                user.Email = model.Email;
                await _userManager.UpdateAsync(user);
            }

            return Ok(HttpStatusCode.OK);
        }

        [HttpPut]
        [Authorize]
        [Route("Password")]
        public async Task<object> PutPassword(NewPassword password)
        {
            var userId = User.Claims.First(claim => claim.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                var newPassword = _userManager.PasswordHasher.HashPassword(user, password.Password);
                user.PasswordHash = newPassword;
                await _userManager.UpdateAsync(user);
            }

            return Ok(HttpStatusCode.OK);
        }

        [HttpPut]
        [Authorize]
        [Route("ExtraInfo")]
        public async Task<object> PutPassword(Info info)
        {
            var userId = User.Claims.First(claim => claim.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                user.ProgramingLanguage = info.ProgrammingLanguage;
                user.ExtraInfo = info.ExtraInfo;
                await _userManager.UpdateAsync(user);
            }

            return Ok(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Authorize]
        [Route("DeleteUser")]
        public async Task<object> DeleteUser()
        {
            var userId = User.Claims.First(claim => claim.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);

            await _userManager.DeleteAsync(user);

            return Ok(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Authorize]
        [Route("DeleteProgress")]
        public async Task<object> DeleteProgress()
        {
            var userId = User.Claims.First(claim => claim.Type == "UserID").Value;
            var entity = _context.ProblemUsers.Where(pu => pu.Id == userId).ToList();

            _context.ProblemUsers.RemoveRange(entity);

            await _context.SaveChangesAsync();

            return Ok(HttpStatusCode.OK);
        }
    }

    public class BasicInfo
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }

    public class NewPassword
    {
        public string Password { get; set; }
    }

    public class Info
    {
        public string ProgrammingLanguage { get; set; }
        public string ExtraInfo { get; set; }
    }

    public class Image
    {
        public string Base64Image { get; set; }
    }
}
