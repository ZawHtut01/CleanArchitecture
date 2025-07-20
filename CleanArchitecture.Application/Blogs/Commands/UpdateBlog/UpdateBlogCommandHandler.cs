using AutoMapper;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
    {
        private readonly IBlogReporitory _blogRepository;
        private readonly IMapper _mapper;
        public UpdateBlogCommandHandler(IBlogReporitory blogRepository,IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = new Blog()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Author = request.Author
            };

            var data = await _blogRepository.UpdateBlogAsync(request.Id, blog);

            return data;
        }
    }
}
