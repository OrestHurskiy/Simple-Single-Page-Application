using CoreValueContacts.API.Client.Clients.Interfaces;
using CoreValueContacts.API.Model.Dtos;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using CoreValueContacts.API.Client.MediaTypeFormatters;
using WebApiDoodle.Net.Http.Client;
using CoreValueContacts.API.Model.RequestModels;
using System.Collections.Generic;
using WebApiDoodle.Net.Http.Client.Model;

namespace CoreValueContacts.API.Client.Clients.Implementation
{
    public class ProjectsClient : HttpApiClient<ProjectDto>, IProjectsClient
    {
        private const string BaseUriTemplate = "api/projects";
        private const string BaseUriTemplateForSingle = "api/projects/{key}";

        public ProjectsClient(HttpClient httpClient): base(httpClient, MediaTypeFormatterCollection.Instance)
        {

        }

        public async Task<ProjectDto> GetProjectAsync(Guid projectKey)
        {
            var parameters = new { key = projectKey };

            using (var apiResponse = await GetSingleAsync(BaseUriTemplate, parameters))
            {
                if(apiResponse.IsSuccess)
                {
                    return apiResponse.Model;
                }

                throw new HttpApiRequestException(string.Format(ErrorMessages.HttpRequestErrorFormat, 
                    (int)apiResponse.Response.StatusCode, apiResponse.Response.ReasonPhrase), 
                    apiResponse.Response.StatusCode, apiResponse.HttpError);
            }
        }

        public Task<ProjectDto> AddProjectAsync(ProjectRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectDto> UpdateProjectAsync(Guid id, ProjectRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProjectAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedDto<ProjectDto>> GetProjects()
        {
            using (var apiResponse = await GetAsync(BaseUriTemplate))
            {
                if(apiResponse.IsSuccess)
                {
                    return apiResponse.Model;
                }

                throw new HttpApiRequestException(string.Format(ErrorMessages.HttpRequestErrorFormat,
                    (int)apiResponse.Response.StatusCode, apiResponse.Response.ReasonPhrase),
                    apiResponse.Response.StatusCode, apiResponse.HttpError);
            }
        }
    }
}
