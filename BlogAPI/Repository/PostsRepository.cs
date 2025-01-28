using BlogAPI.Interfaces;
using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Repository
{
    public class PostsRepository : IPostsRepository
    {
        public readonly BlogDbContext _context;

        public PostsRepository(BlogDbContext context)
        {
            _context = context;
        }

        public Task<List<Post>> GetPostsAsync()
        {
            return _context.Posts.ToListAsync();
        }

        public Task<Post?> GetPostByIdAsync(int id)
        {
            return _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Post> CreatePostAsync(Post post)
        {
            if(post == null) throw new ArgumentNullException(nameof(post));

            await _context.AddAsync(post);
            await _context.SaveChangesAsync();

            return post;
        }

        public async Task<Post> UpdatePostAsync(int id, Post post)
        {
            if (post == null) throw new ArgumentNullException(nameof(post));

            var existingPost = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);

            if (existingPost == null) throw new ArgumentException($"Post with id {id} not found");

            existingPost.Title = string.IsNullOrEmpty(post.Title) ? existingPost.Title : post.Title;
            existingPost.Content = string.IsNullOrEmpty(post.Content) ? existingPost.Content : post.Content;
            existingPost.UpdatedDate = DateTime.Now;

            await _context.SaveChangesAsync();

            return existingPost;
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);

            if (post == null) throw new ArgumentException($"Post with id {id} not found");

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }
    }
}
