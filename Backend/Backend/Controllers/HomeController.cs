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
            var problems = await _context.Problems
                .Select(p => new
                {
                    problemId = p.ProblemId,
                    title = p.Title,
                    description = p.Description,
                    solvedBy = p.SolvedBy,
                    difficulty = p.Difficulty,
                    releaseDate = p.ReleaseDate,
                    tags = p.ProblemTags.Select(pt => pt.Tag).Select( t => new
                    {
                        tagId = t.TagId,
                        tagName = t.TagName
                    })
                })
                .ToListAsync();

            return Ok(problems);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> GetProblem(int id)
        {
            var problem = await _context.Problems
                .Select(p => new
                    {
                        problemId = p.ProblemId,
                        title = p.Title,
                        description = p.Description,
                        solvedBy = p.SolvedBy,
                        difficulty = p.Difficulty,
                        releaseDate = p.ReleaseDate,
                        tags = p.ProblemTags.Select(pt => pt.Tag).Select( t => new
                        {
                            tagId = t.TagId,
                            tagName = t.TagName
                        })
                    })
                .SingleOrDefaultAsync(p=> p.problemId == id);

            return Ok(problem);
        }
    }
}
