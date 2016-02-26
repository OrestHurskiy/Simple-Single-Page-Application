using AutoMapper;
using CoreValueContacts.API.Model.Dtos;
using CoreValueContacts.Domain.Entities;

namespace CoreValueContacts.API.Config
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Project, ProjectDto>().ReverseMap();
        }
    }
}
