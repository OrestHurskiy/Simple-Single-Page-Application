using System;
using CoreValueContacts.Domain.Entities;
using CoreValueContacts.Services.Services.HelperClasses;
using System.Collections.Generic;
using CoreValueContacts.Domain.Entities.Core;

namespace CoreValueContacts.Services.Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProjectService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        OperationResult<Project> AddProject(Project project);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        Project UpdateProject(Project project);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        OperationResult DeleteProject(Project project);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Project GetProject(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IList<Project> GetProjects();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        PaginatedList<Project> GetProjects(int pageSize, int pageIndex);
    }
}
