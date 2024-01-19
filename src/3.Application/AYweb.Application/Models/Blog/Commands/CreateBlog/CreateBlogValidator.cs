using FluentValidation;

namespace AYweb.Application.Models.Blog.Commands.CreateBlog;

public class CreateBlogValidator:AbstractValidator<CreateBlogCommand>
{
    public CreateBlogValidator()
    {
        
    }
}
