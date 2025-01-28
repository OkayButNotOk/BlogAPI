using BlogAPI.Interfaces;
using BlogAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace BlogAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        public readonly IPostsService _postsService;

        public PostsController(IPostsService postsService)
        {
            _postsService = postsService;
        }

        [HttpGet("api/posts")]
        public async Task<IActionResult> GetPostsAsync()
        {
            var posts = await _postsService.GetPostsAsync();
            
            return Ok(posts);
        }

        [HttpGet("api/posts/{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var post = await _postsService.GetPostByIdAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }


        [HttpPost("api/posts")]
        public async Task<IActionResult> CreatePostAsync([FromBody] Post post)
        {
            if (post == null) return BadRequest();

            var createdPost = await _postsService.CreatePostAsync(post);

            return CreatedAtAction(nameof(GetPostById), new { id = createdPost.Id }, createdPost);
        }

        [HttpPut("api/posts/{id}")]
        public async Task<IActionResult> UpdatePostAsync(int id, [FromBody] Post post)
        {
            if (post == null) return BadRequest();

            var existingPost = await _postsService.GetPostByIdAsync(id);

            if (existingPost == null) return NotFound();

            var updatedPost = await _postsService.UpdatePostAsync(id, post);

            return Ok(updatedPost);
        }

        [HttpDelete("api/posts/{id}")]
        public async Task<IActionResult> DeletePostAsync(int id)
        {
            var existingPost = await _postsService.GetPostByIdAsync(id);

            if (existingPost == null) return NotFound();

            await _postsService.DeletePostAsync(id);

            return NoContent();
        }
    }
}
