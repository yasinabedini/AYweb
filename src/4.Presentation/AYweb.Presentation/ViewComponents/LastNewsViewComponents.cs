using AYweb.Application.Models.Blog.Queries.GetBlogs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AYweb.Web.ViewComponents;

public class LastNewsViewComponents:ViewComponent
{
    private readonly ISender _sender;

    public LastNewsViewComponents(ISender sender)
    {
        _sender = sender;
    }


    public async Task<IViewComponentResult> InvokeAsync()
    {
        return await Task.FromResult((IViewComponentResult)View("LastNews",_sender.Send(new GetBlogsQuery()).Result.QueryResult.Take(3).ToList()));
    }
}