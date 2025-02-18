using Common.DTOs;

namespace BusinessLogic.Services.Interfaces
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogDTO>> GetAllBlogsAsync();
        Task<BlogDTO> GetBlogByIdAsync(int id);
        Task AddBlogAsync(BlogDTO blogDTO);
        Task UpdateBlogAsync(BlogDTO blogDTO);
        Task DeleteBlogAsync(int id);
    }
}
