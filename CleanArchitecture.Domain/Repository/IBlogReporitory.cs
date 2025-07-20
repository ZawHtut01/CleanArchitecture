using CleanArchitecture.Domain.Entity;

namespace CleanArchitecture.Domain.Repository
{
    public interface IBlogReporitory
    {
        Task<List<Blog>> GetAllBlogsAsync();
        Task<Blog> GetByIdAsync(int id);
        Task<Blog> CreateBlog(Blog blog);
        Task<int> UpdateBlogAsync(int id,Blog blog);
        Task<int> DeleteBlogById(int id);
    }
}
