﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
