using AutoMapper;
using CleanArchitecture.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, int>
    {
        private readonly IBlogReporitory _blogReporitory;

        public DeleteBlogCommandHandler(IBlogReporitory blogRepository)
        {
            _blogReporitory = blogRepository;
        }
        public async Task<int> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var data = await _blogReporitory.DeleteBlogById(request.Id);

            return data;
        }
    }
}
