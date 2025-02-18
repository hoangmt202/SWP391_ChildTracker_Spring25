using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using BusinessLogic.Service.Interface;
using Common.DTOs.Blog;
using DataAccess.Context;
using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Service.Implement
{
    public class BlogService : IBlogService
    {
        private readonly AppDbContext _context;

        public BlogService(AppDbContext context)
        {
            _context = context ?? new AppDbContext();
        }


       public async Task AddBlogAsync(CreateBlogRequest request)
{
        if (request == null)
            {
        throw new ArgumentNullException(nameof(request), "Request cannot be null");
            }

        BlogEntity blog = new BlogEntity
             {
        AuthorId = request.AuthorId,
        Title = request.Title,
        Content = request.Content,
        ImageUrl = request.ImageUrl,
        Status = "Draft",
        CreatedAt = DateTime.UtcNow
            };

         _context.Blogs.Add(blog);
        await _context.SaveChangesAsync();
}



        public async Task<bool> DeleteBlogAsync(int i)
        {
           BlogEntity blog = _context.Blogs.FirstOrDefault(x => x.BlogId == i);
            if (blog == null)
            {
                return false;
            }
            else
            {
                _context.Blogs.Remove(blog);
                await _context.SaveChangesAsync();
                return true;

            }
        }

        public async Task<IEnumerable<GetBlogResponse>> GetAllBlogsAsync()
        {
            List<BlogEntity> blogEntities = _context.Blogs.ToList();
            List<GetBlogResponse> getBlogResponses = new List<GetBlogResponse>();
            foreach (var blogEntity in blogEntities)
            {
                getBlogResponses.Add(new GetBlogResponse
                {
                    BlogId = blogEntity.BlogId,
                    AuthorId = blogEntity.AuthorId,
                    Title = blogEntity.Title,
                    Content = blogEntity.Content,
                    ImageUrl = blogEntity.ImageUrl,
                    Views = blogEntity.Views,
                    Likes = blogEntity.Likes,
                    Status = blogEntity.Status,
                    CreatedAt = blogEntity.CreatedAt,
                });
            }

            return getBlogResponses;
        }

        public async Task<GetBlogResponse> GetBlogByIdAsync(int id)
        {
            BlogEntity blogEntity = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            GetBlogResponse getBlogResponse = new GetBlogResponse
            {
                BlogId = blogEntity.BlogId,
                AuthorId = blogEntity.AuthorId,
                Title = blogEntity.Title,
                Content = blogEntity.Content,
                ImageUrl = blogEntity.ImageUrl,
                Views = blogEntity.Views,
                Likes = blogEntity.Likes,
                Status = blogEntity.Status,
                CreatedAt = blogEntity.CreatedAt,
            };
            return getBlogResponse;
        }

        public async Task<bool> UpdateBlogAsync(int id, UpdateBlogResquest updateBlogResquest)
        {
            BlogEntity blogEntity = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (blogEntity != null)
            {
                blogEntity.Title = updateBlogResquest.Title;
                blogEntity.Content = updateBlogResquest.Content;
                blogEntity.ImageUrl = updateBlogResquest.ImageUrl;
                _context.Blogs.Update(blogEntity);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
