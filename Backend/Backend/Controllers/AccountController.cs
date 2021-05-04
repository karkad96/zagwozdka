using System;
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
        private ILogger<AccountController> _logger;

        public AccountController(UserManager<ApplicationUser> userManager, Context context, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public async Task<object> GetAccount()
        {
            var userId = User.Claims.First(claim => claim.Type == "UserID").Value;
            var details = await _context.ApplicationUsers
                .Where(u => u.Id == userId)
                .Select(u => new
                {
                    userName = u.UserName,
                    email = u.Email,
                    programmingLanguage = u.ProgramingLanguage,
                    extraInfo = u.ExtraInfo
                }).SingleOrDefaultAsync();

            var b = await System.IO.File.ReadAllBytesAsync("../Backend/Data/Images/blank.png");

            return Ok(new {details.userName, details.email,
                details.programmingLanguage, details.extraInfo,
                image = File(b, "image/png").FileContents});
        }

        [HttpPut]
        [Authorize]
        [Route("BasicInfo")]
        public async Task<object> PutBasicInfo(BasicInfo model)
        {
            var userId = User.Claims.First(claim => claim.Type == "UserID").Value;
            var entity = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (entity != null)
            {
                entity.UserName = model.UserName;
                entity.Email = model.Email;
                await _context.SaveChangesAsync();
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
}
