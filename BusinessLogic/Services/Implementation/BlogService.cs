
using DataAccess.Repository.Interfaces;
using DataAccess.Entity;
using Common.DTOs;
using BusinessLogic.Services.Interfaces;


namespace BusinessLogic.Services.Implementation
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IEnumerable<BlogDTO>> GetAllBlogsAsync()
        {
            var blogs = await _blogRepository.GetAllBlogsAsync();
            return blogs.Select(blog => new BlogDTO
            {
                BlogId = blog.BlogId,
                AuthorId = blog.AuthorId,
                Title = blog.Title,
                Content = blog.Content,
                ImageUrl = blog.ImageUrl,
                Views = blog.Views,
                Likes = blog.Likes,
                Status = blog.Status,
                CreatedAt = blog.CreatedAt
            }).ToList();
        }

        public async Task<BlogDTO> GetBlogByIdAsync(int id)
        {
            var blog = await _blogRepository.GetBlogByIdAsync(id);
            return new BlogDTO
            {
                BlogId = blog.BlogId,
                AuthorId = blog.AuthorId,
                Title = blog.Title,
                Content = blog.Content,
                ImageUrl = blog.ImageUrl,
                Views = blog.Views,
                Likes = blog.Likes,
                Status = blog.Status,
                CreatedAt = blog.CreatedAt
            };
        }

        public async Task AddBlogAsync(BlogDTO blogDTO)
        {
            var blog = new BlogEntity
            {
                AuthorId = blogDTO.AuthorId,
                Title = blogDTO.Title,
                Content = blogDTO.Content,
                ImageUrl = blogDTO.ImageUrl,
                Views = 0,
                Likes = 0,
                Status = blogDTO.Status,
                CreatedAt = blogDTO.CreatedAt
            };
            await _blogRepository.AddBlogAsync(blog);
        }

        public async Task UpdateBlogAsync(BlogDTO blogDTO)
        {
            var blog = await _blogRepository.GetBlogByIdAsync(blogDTO.BlogId);
            if (blog != null)
            {
                blog.Title = blogDTO.Title;
                blog.Content = blogDTO.Content;
                blog.ImageUrl = blogDTO.ImageUrl;
                blog.Status = blogDTO.Status;
                await _blogRepository.UpdateBlogAsync(blog);
            }
        }

        public async Task DeleteBlogAsync(int id)
        {
            await _blogRepository.DeleteBlogAsync(id);
        }
    }
}
