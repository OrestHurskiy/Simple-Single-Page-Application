using CoreValueContacts.Services.Services.Interfaces;
using CoreValueContacts.Domain.Repositories;
using CoreValueContacts.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using CoreValueContacts.Domain.Entities;
using CoreValueContacts.Services.Services.HelperClasses;
using CoreValueContacts.Domain.Entities.Core;

namespace CoreValueContacts.Services.Services.Implementation
{
    public class ProjectService : IProjectService
    {
        private readonly IEntityBaseRepository<Project> _projectRepository;
        private readonly IMembershipService _membershipService;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IEntityBaseRepository<Project> projectRepository, IMembershipService membershipService, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _membershipService = membershipService;
            _unitOfWork = unitOfWork;
        }

        public OperationResult<Project> AddProject(Project project)
        {
            project.Id = Guid.NewGuid();
            _projectRepository.Add(project);
            _unitOfWork.Commit();

            return new OperationResult<Project>(true) { Entity = project };
        }

        public Project UpdateProject(Project project)
        {
            _projectRepository.Update(project);
            _unitOfWork.Commit();
            return project;
        }

        public OperationResult DeleteProject(Project project)
        {
            _projectRepository.Delete(project);
            _unitOfWork.Commit();
            return new OperationResult(true);
        }

        public Project GetProject(Guid id)
        {
            return _projectRepository.GetSingle(id);
        }

        public IList<Project> GetProjects()
        {
            return _projectRepository.GetAll().ToList();
        }

        public PaginatedList<Project> GetProjects(int pageSize, int pageIndex)
        {
            return _projectRepository.Paginate(pageIndex, pageSize);
        }
    }
}
