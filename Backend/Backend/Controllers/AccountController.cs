using System;
using System.Linq;
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
                    email = u.Email
                }).SingleOrDefaultAsync();

            return Ok(details);
        }
    }
}
