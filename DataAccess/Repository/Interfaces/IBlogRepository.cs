using DataAccess.Entity;

namespace DataAccess.Repository.Interfaces
{
    public interface IBlogRepository
    {
        Task<IEnumerable<BlogEntity>> GetAllBlogsAsync();
        Task<BlogEntity> GetBlogByIdAsync(int id);
        Task AddBlogAsync(BlogEntity blog);
        Task UpdateBlogAsync(BlogEntity blog);
        Task DeleteBlogAsync(int id);
    }
}
