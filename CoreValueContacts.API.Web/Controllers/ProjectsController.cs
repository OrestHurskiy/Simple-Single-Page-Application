using CoreValueContacts.API.Client.Clients.Interfaces;
using CoreValueContacts.API.Model.Dtos;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CoreValueContacts.API.Web.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectsClient _projectsClient;

        public ProjectsController(IProjectsClient projectsClient)
        {
            _projectsClient = projectsClient;
        }

        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var project = await _projectsClient.GetProjectAsync(id);
            return View("Details", project);
        }

        // GET: Projects
        public async Task<ActionResult> Index()
        {
            var projects = await _projectsClient.GetProjects();
            return View();
        }
    }
}