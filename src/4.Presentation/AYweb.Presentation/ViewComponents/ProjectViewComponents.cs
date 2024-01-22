using AYweb.Application.Models.Project.Queries.GetProjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AYweb.Web.ViewComponents;

public class ProjectViewComponents:ViewComponent
{
    private readonly ISender _sender;

    public ProjectViewComponents(ISender sender)
    {
        _sender = sender;
    }
   
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return await Task.FromResult((IViewComponentResult)View("Projects",_sender.Send(new GetProjectsQuery())));
    }
}   