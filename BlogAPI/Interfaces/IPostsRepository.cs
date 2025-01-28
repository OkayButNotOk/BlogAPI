using BlogAPI.Models;

namespace BlogAPI.Interfaces
{
    public interface IPostsRepository
    {
        Task<List<Post>> GetPostsAsync();
        Task<Post?> GetPostByIdAsync(int id);
        Task<Post> CreatePostAsync(Post post);
        Task<Post> UpdatePostAsync(int id, Post post);
        Task DeletePostAsync(int id);
    }
}
