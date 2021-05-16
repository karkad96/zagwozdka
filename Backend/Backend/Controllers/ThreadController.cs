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
using Z.EntityFramework.Plus;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThreadController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Context _context;
        private readonly ILogger<ThreadController> _logger;

        public ThreadController(UserManager<ApplicationUser> userManager, Context context,
            ILogger<ThreadController> logger)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public async Task<object> GetPosts(int id)
        {
            var userId = User.FindFirst("UserID")?.Value;
            var posts = await _context.Posts
                .Where(p => p.ProblemId == id)
                .Select(p => new
                {
                    postId = p.PostId,
                    content = p.Content,
                    likes = p.Likes,
                    userName = p.ApplicationUser.UserName,
                    programmingLanguage = p.ApplicationUser.ProgramingLanguage,
                    isOwner = p.UserId == userId,
                    isLiked = p.PostUsers
                        .Any(pu => pu.UserId == userId)
                })
                .ToListAsync();

            return Ok(posts);
        }

        [HttpPost]
        [Authorize]
        [Route("{id}")]
        public async Task<object> PostLike(int id, Like like)
        {
            var userId = User.Claims.First(claim => claim.Type == "UserID").Value;
            var entry = new PostUser
            {
                PostId = like.postId,
                UserId = userId,
                Likes = 1
            };

            await _context.PostUsers.AddAsync(entry);
            await _context.Posts.Where(p => p.PostId == like.postId)
                .UpdateAsync(p => new Post { Likes = p.Likes + 1 });
            await _context.SaveChangesAsync();

            return Ok();
        }
    }

    public class Like
    {
        public int postId { get; set; }
    }
}
