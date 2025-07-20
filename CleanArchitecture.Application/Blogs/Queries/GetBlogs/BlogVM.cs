using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entity;

namespace CleanArchitecture.Application.Blogs.Queries.GetBlogs
{
    public class BlogVM : IMapForm<Blog>
    {
        public int Id {  get; set; }
        public string Name {  get; set; }
        public string Description { get; set; }
        public string Author {  get; set; }
    }
}
