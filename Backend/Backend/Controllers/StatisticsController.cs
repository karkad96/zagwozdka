using System;
using System.Globalization;
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
using Z.EntityFramework.Plus;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Context _context;
        private readonly ILogger<StatisticsController> _logger;

        public StatisticsController(UserManager<ApplicationUser> userManager, Context context,
            ILogger<StatisticsController> logger)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public async Task<object> GetStatistics()
        {
            var userId = User.FindFirst("UserID")?.Value;

            var problems = await _context.Problems
                .Select(p => new
                {
                    problemId = p.ProblemId,
                    title = p.Title,
                    solvedBy = p.SolvedBy,
                    difficulty = p.Difficulty,
                    solvedDate = p.ProblemUsers
                        .Where(pu => pu.Id == userId && pu.ProblemId == p.ProblemId)
                        .Select(pu => pu.SolvedDate).First().ToString(CultureInfo.InvariantCulture),
                    isSolved = p.ProblemUsers
                        .Any(pu => pu.Id == userId && pu.ProblemId == p.ProblemId),

                })
                .ToListAsync();

            var ratings = await _context.Problems
                .Select(p => new
                {
                    difficulty = p.Difficulty,
                    solved = p.ProblemUsers
                        .Any(pu => pu.Id == userId && pu.ProblemId == p.ProblemId)
                }).ToListAsync();

            var posts = await _context.Posts
                .Where(p => userId == p.UserId)
                .Select( p => new {
                    problemId = p.ProblemId,
                    postId = p.PostId,
                    likes = p.Likes,
                    reports = p.Reports
                }).ToListAsync();

            var history = await _context.ProblemUsers
                .Where(pu => pu.Id == userId)
                .Select(pu => new
                {
                    problemId = pu.ProblemId,
                    solvedDate = pu.SolvedDate
                })
                .OrderByDescending(p => p.solvedDate)
                .ToListAsync();

            var info = await _context.Problems.CountAsync();
            var userName = _userManager.FindByIdAsync(userId).Result.UserName;

            return Ok(new {problems, ratings, posts, history, info, userName});
        }
    }
}
