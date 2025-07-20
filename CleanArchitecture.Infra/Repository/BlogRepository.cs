using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Repository;
using CleanArchitecture.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infra.Repository
{
    public class BlogRepository : IBlogReporitory
    {
        private readonly BlogDbContext _context;
        public BlogRepository(BlogDbContext context)
        {
            _context = context;
        }
        public async Task<Blog> CreateBlog(Blog blog)
        {
            await _context.Blogs.AddAsync(blog);
            //await _context.SaveChangesAsync();

            return blog;
        }

        public async Task<int> DeleteBlogById(int id)
        {
            var data = await _context.Blogs.Where(x => x.Id == id).ExecuteDeleteAsync();

            return data;
        }

        public async Task<List<Blog>> GetAllBlogsAsync()
        {
            var data = await _context.Blogs.ToListAsync();
            return data;
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            var data = await _context.Blogs.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<int> UpdateBlogAsync(int id, Blog blog)
        {
            var data = await _context.Blogs.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data != null)
            {
                _context.Blogs.Update(data);
                await _context.SaveChangesAsync();

                return 1;
            }
            return 0;
        }
    }
}
