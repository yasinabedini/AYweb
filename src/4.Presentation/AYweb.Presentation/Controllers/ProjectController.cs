using AYweb.Application.Models.Project.Queries.GetProject;
using AYweb.Application.Models.Project.Queries.GetProjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AYweb.Presentation.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ISender _sender;

        public ProjectController(ISender sender)
        {
            _sender = sender;
        }

       
        public IActionResult Index()
        {
            return View(_sender.Send(new GetProjectsQuery()).Result);
        }

        public IActionResult ProjectDetails(int id)
        {
            return View(_sender.Send(new GetProjectQuery() { Id = id}).Result);
        }
    }
}
