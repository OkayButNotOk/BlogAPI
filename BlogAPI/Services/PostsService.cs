using BlogAPI.Interfaces;
using BlogAPI.Models;

namespace BlogAPI.Services
{
    public class PostsService : IPostsService
    {
        public readonly IPostsRepository _postsRepository;

        public PostsService(IPostsRepository postsRepository)
        {
            _postsRepository = postsRepository;
        }

        public Task<List<Post>> GetPostsAsync()
        {
            return _postsRepository.GetPostsAsync();
        }

        public Task<Post?> GetPostByIdAsync(int id)
        {
            return _postsRepository.GetPostByIdAsync(id);
        }

        public Task<Post> CreatePostAsync(Post post)
        {
            if(post == null) throw new ArgumentNullException(nameof(post));

            return _postsRepository.CreatePostAsync(post);
        }

        public Task<Post> UpdatePostAsync(int id, Post post)
        {
            if (post == null) throw new ArgumentNullException(nameof(post));

            return _postsRepository.UpdatePostAsync(id, post);
        }

        public Task DeletePostAsync(int id) 
        { 
            return _postsRepository.DeletePostAsync(id); 
        }
    }
}
