using AYweb.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AYweb.Web.ViewComponents;

public class CommentViewComponents
{
    private readonly IProductService _service;

    public CommentViewComponents(IProductService service)
    {
        _service = service;
    }

    //public async Task<IViewComponentResult> InvokrAsync()
    //{
    //    //return Task.FromResult((IViewComponentResult)View("Comments"))
    //    return null;
    //}
}