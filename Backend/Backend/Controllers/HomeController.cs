using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Context _context;

        public HomeController(UserManager<ApplicationUser> userManager, Context context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<object> GetProblems()
        {
            var problems = await _context.Problems.Include(p => p.Tags).ToListAsync();

            return Ok(problems);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> GetProblem(int id)
        {
            var problem = await _context.Problems.Where(p=> p.ProblemId == id).Include(p => p.Tags).ToListAsync();

            return Ok(problem);
        }
    }
}
