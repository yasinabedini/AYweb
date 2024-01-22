using AYweb.Application.Models.Plan.Queries.GetPlans;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AYweb.Web.ViewComponents;

public class PlansViewComponents : ViewComponent
{
    private readonly ISender _sender;

    public PlansViewComponents(ISender sender)
    {
        _sender = sender;
    }  

    public async Task<IViewComponentResult> InvokeAsync()
    {
        return await Task.FromResult((IViewComponentResult)View("Plans", _sender.Send(new GetPlansQuery())));
    }
}