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
    public class ProblemController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Context _context;
        private ILogger<ProblemController> _logger;

        public ProblemController(UserManager<ApplicationUser> userManager, Context context, ILogger<ProblemController> logger)
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
            var result = await GetAnswer(id);
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
                        result
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
                return Ok();
            }

            var userId = User.Claims.First(claim => claim.Type == "UserID").Value;
            var solvedDate = DateTime.Now;
            var solved = new ProblemUser
            {
                ProblemId = id,
                Id = userId,
                SolvedDate = solvedDate
            };

            await _context.ProblemUsers.AddAsync(solved);
            await _context.SaveChangesAsync();

            return Ok(new {answer = realAnswer, solvedDate});
        }

        private async Task<object?> GetAnswer(int id)
        {
            var userId = User.FindFirst("UserID")?.Value;
            var isSolved = await _context.ProblemUsers.AnyAsync(pu => pu.Id == userId && pu.ProblemId == id);
            object? result = null;
            if (isSolved)
            {
                var answer = await _context.Problems
                    .Where(p => p.ProblemId == id)
                    .Select(p => p.Answer)
                    .FirstOrDefaultAsync();
                var solvedDate = await _context.ProblemUsers
                    .Where(pu => pu.ProblemId == id && pu.Id == userId)
                    .Select(pu => pu.SolvedDate)
                    .FirstOrDefaultAsync();
                result = new
                {
                    answer,
                    solvedDate
                };
            }

            return result;
        }

        public class Result
        {
            public string Answer { get; set; }
        }
    }
}
