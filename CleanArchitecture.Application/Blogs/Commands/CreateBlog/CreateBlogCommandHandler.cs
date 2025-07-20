using AutoMapper;
using CleanArchitecture.Application.Blogs.Queries.GetBlogs;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Repository;
using MediatR;

namespace CleanArchitecture.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogVM>
    {
        private readonly IBlogReporitory _blogRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CreateBlogCommandHandler(IBlogReporitory blogRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BlogVM> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {

            var blogEntity = new Blog()
            {
                Name = request.Name,
                Description = request.Description,
                Author = request.Author
            };

            var result = await _blogRepository.CreateBlog(blogEntity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<BlogVM>(result);
        }
    }
}
