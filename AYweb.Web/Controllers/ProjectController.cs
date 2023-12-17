using AYweb.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AYweb.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _service;

        public ProjectController(IProjectService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.GetAllProject());
        }

        public IActionResult ProjectDetails(int id)
        {
            return View(_service.GetProjectById(id));
        }
    }
}
