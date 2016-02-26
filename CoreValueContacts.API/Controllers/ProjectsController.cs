using CoreValueContacts.API.Model.Dtos;
using CoreValueContacts.Domain.Entities;
using CoreValueContacts.Services.Services.Interfaces;
using System;
using System.Net;
using System.Web.Http;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace CoreValueContacts.API.Controllers
{
    [RoutePrefix("api/projects")]
    public class ProjectsController : ApiController
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        //[Route("")]
        public IList<ProjectDto> GetProjects()
        {
            var projects = _projectService.GetProjects();

            if (projects == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var projectsDto = projects.Select(pr => new ProjectDto { Id = pr.Id, Name = pr.Name, NumberOfEmployers = pr.NumberOfEmployers }).ToList();

            return projectsDto;
        }

        
        public ProjectDto GetProject(Guid key)
        {
            var project = _projectService.GetProject(key);

            if(project == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var projectDto = new ProjectDto { Id = project.Id, Name = project.Name, NumberOfEmployers = project.NumberOfEmployers };

            return projectDto;
        }
    }
}
