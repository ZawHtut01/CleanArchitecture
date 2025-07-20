using CleanArchitecture.Application.Blogs.Commands.CreateBlog;
using CleanArchitecture.Application.Blogs.Commands.DeleteBlog;
using CleanArchitecture.Application.Blogs.Commands.UpdateBlog;
using CleanArchitecture.Application.Blogs.Queries.GetBlogById;
using CleanArchitecture.Application.Blogs.Queries.GetBlogs;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Repository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ApiControllerBase
    {
        private readonly IBlogReporitory _repo;
        public BlogController(IBlogReporitory repo)
        {
            _repo = repo;
        }
        [HttpGet("GetBlogs")]
        public async Task<IActionResult> GetBlogs()
        {
            try
            {
                var data = await Mediator.Send(new GetBlogQuery());
                if (data == null) throw new Exception("Data Not Found.....");
                return Ok(new Common.CommonResponse<List<BlogVM>>()
                {
                    Success = true,
                    Message = "Success",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return Ok(new Common.CommonResponse<string>()
                {
                    Success = false,
                    Message = ex.ToString(),
                    Data = null
                });
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await Mediator.Send(new GetBlogByIdQuery() { BlogId = id });
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(new Common.CommonResponse<BlogVM>
            {
                Success = true,
                Message = "Success",
                Data = blog
            });
        }

        [HttpPost("CreateBlog")]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            var blog = await Mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = blog.Id }, blog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlog(int id, UpdateBlogCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            await Mediator.Send(new DeleteBlogCommand { Id = id });
            return NoContent();
        }

    }
}
