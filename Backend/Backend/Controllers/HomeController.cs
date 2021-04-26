using System;
using System.Linq;
using System.Security.Claims;
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
    public class HomeController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Context _context;
        private ILogger<HomeController> _logger;

        public HomeController(UserManager<ApplicationUser> userManager, Context context, ILogger<HomeController> logger)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<object> GetProblems()
        {
            var userId = User.FindFirst("UserID")?.Value;
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
                    }),
                    isSolved = p.ProblemUsers
                        .Any(pu => pu.Id == userId && pu.ProblemId == p.ProblemId)
                })
                .ToListAsync();

            return Ok(problems);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> GetProblem(int id)
        {
            var userId = User.FindFirst("UserID")?.Value;
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
                        }),
                        isSolved = p.ProblemUsers
                        .Any(pu => pu.Id == userId && pu.ProblemId == p.ProblemId)
                    })
                .SingleOrDefaultAsync(p=> p.problemId == id);

            return Ok(problem);
        }

        [HttpPost]
        [Authorize]
        [Route("{id}")]
        public async Task<object> PostAnswer(int id, Result answer)
        {
            var realAnswer = await _context.Problems
                .Where(p => p.ProblemId == id)
                .Select(p => p.Answer)
                .FirstOrDefaultAsync();

            if (realAnswer != answer.Answer)
            {
                return Ok(new {response = false});
            }

            var userId = User.Claims.First(claim => claim.Type == "UserID").Value;
            var solved = new ProblemUser
            {
                ProblemId = id,
                Id = userId,
                SolvedDate = DateTime.Now
            };

            await _context.ProblemUsers.AddAsync(solved);
            await _context.SaveChangesAsync();

            return Ok(new {response = true});
        }
    }
}
