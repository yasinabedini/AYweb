using AYweb.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;

namespace AYweb.Web.ViewComponents;

public class LastNewsViewComponents:ViewComponent
{
    private readonly IBlogService _service;

    public LastNewsViewComponents(IBlogService service)
    {
        _service = service;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        return await Task.FromResult((IViewComponentResult)View("LastNews", _service.GetAllNews().Item1.Take(3).ToList()));
    }
}