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
                    postDate = p.PostDate,
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

            var liked = like.liked ? 1 : -1;

            if (like.liked)
            {
                await _context.PostUsers.AddAsync(entry);
            }
            else
            {
                _context.PostUsers.Remove(entry);
            }

            await _context.Posts.Where(p => p.PostId == like.postId)
                .UpdateAsync(p => new Post { Likes = p.Likes + liked });
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Authorize]
        [Route("{id}/Post")]
        public async Task<object> PostPost(int id, PostModel post)
        {
            var userId = User.Claims.First(claim => claim.Type == "UserID").Value;
            var entry = new Post
            {
                UserId = userId,
                ProblemId = id,
                Content = post.Content,
                Likes = 0,
                PostDate = DateTime.Now
            };

            await _context.Posts.AddAsync(entry);
            await _context.SaveChangesAsync();

            return GetPosts(id).Result;
        }

        [HttpPut]
        [Authorize]
        [Route("{id}")]
        public async Task<object> PutPost(int id, PutModel put)
        {
            var entity = await _context.Posts.FirstOrDefaultAsync(p => p.PostId == put.PostId);
            if (entity != null)
            {
                entity.Content = put.Content;
                await _context.SaveChangesAsync();
            }

            return GetPosts(id).Result;
        }

        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public async Task<object> DeletePost(int id, DeleteModel delete)
        {
            var entity = await _context.Posts.FirstOrDefaultAsync(p => p.PostId == delete.PostId);
            if (entity != null)
            {
                _context.Posts.Remove(entity);
                await _context.SaveChangesAsync();
            }

            return GetPosts(id).Result;
        }
    }

    public class Like
    {
        public int postId { get; set; }
        public bool liked { get; set; }
    }

    public class PostModel
    {
        public string Content { get; set; }
    }

    public class PutModel
    {
        public int PostId { get; set; }
        public string Content { get; set; }
    }

    public class DeleteModel
    {
        public int PostId { get; set; }
    }
}
