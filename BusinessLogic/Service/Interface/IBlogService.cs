using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTOs.Blog;

namespace BusinessLogic.Service.Interface
{
    public interface IBlogService
    {
        Task<GetBlogResponse> GetBlogByIdAsync(int id);
        Task<IEnumerable<GetBlogResponse>> GetAllBlogsAsync();

        Task AddBlogAsync(CreateBlogRequest request);

        Task<bool> UpdateBlogAsync(int id, UpdateBlogResquest updateBlogResquest);

        Task<bool> DeleteBlogAsync(int i);

    }
}
