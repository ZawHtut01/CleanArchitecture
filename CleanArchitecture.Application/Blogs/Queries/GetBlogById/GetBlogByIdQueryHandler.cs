using AutoMapper;
using CleanArchitecture.Application.Blogs.Queries.GetBlogs;
using CleanArchitecture.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Blogs.Queries.GetBlogById
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, BlogVM>
    {
        private readonly IBlogReporitory _blogRepository;
        private readonly IMapper _mapper;
        public GetBlogByIdQueryHandler(IBlogReporitory blogReporitory, IMapper mapper)
        {
            _blogRepository = blogReporitory;
            _mapper = mapper;
        }

        public async Task<BlogVM> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blog = await _blogRepository.GetByIdAsync(request.BlogId);

            var response = _mapper.Map<BlogVM>(blog);

            return response;
        }
    }
}
