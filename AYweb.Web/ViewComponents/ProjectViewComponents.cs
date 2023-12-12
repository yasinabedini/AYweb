using AYweb.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AYweb.Web.ViewComponents;

public class ProjectViewComponents:ViewComponent
{
    private readonly IProjectService _service;

    public ProjectViewComponents(IProjectService service)
    {
        _service = service;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return await Task.FromResult((IViewComponentResult)View("Projects",_service.GetAllProject()));
    }
}   