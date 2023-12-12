using AYweb.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AYweb.Web.ViewComponents;

public class PlansViewComponents : ViewComponent
{
    private readonly IPlanService _planService;

    public PlansViewComponents(IPlanService service)
    {
        _planService = service;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        return await Task.FromResult((IViewComponentResult)View("Plans", _planService.GetAllPlans()));
    }
}