using CoreValueContacts.API.Model.Dtos;
using CoreValueContacts.API.Model.RequestModels;
using System;
using System.Threading.Tasks;
using WebApiDoodle.Net.Http.Client.Model;

namespace CoreValueContacts.API.Client.Clients.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProjectsClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<PaginatedDto<ProjectDto>> GetProjects();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ProjectDto> GetProjectAsync(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        Task<ProjectDto> AddProjectAsync(ProjectRequestModel requestModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        Task<ProjectDto> UpdateProjectAsync(Guid id, ProjectRequestModel requestModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteProjectAsync(Guid id);
    }
}
