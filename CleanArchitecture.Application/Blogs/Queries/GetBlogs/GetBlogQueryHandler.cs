using AutoMapper;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Repository;
using MediatR;

namespace CleanArchitecture.Application.Blogs.Queries.GetBlogs
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<BlogVM>>
    {
        private readonly IBlogReporitory _blogReporitory;
        private readonly IMapper _mapper;

        public GetBlogQueryHandler(IBlogReporitory blogReporitory,IMapper mapper)
        {
            _blogReporitory = blogReporitory;
            _mapper = mapper;
        }
        public async Task<List<BlogVM>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogReporitory.GetAllBlogsAsync();

            var blogList = _mapper.Map<List<BlogVM>>(blogs);

            return blogList;
        }
    }
}
