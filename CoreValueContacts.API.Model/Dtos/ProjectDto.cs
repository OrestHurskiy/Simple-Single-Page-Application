using System;
using WebApiDoodle.Net.Http.Client.Model;

namespace CoreValueContacts.API.Model.Dtos
{
    public class ProjectDto : IDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int NumberOfEmployers { get; set; }

        //public CustomerDto Customer { get; set; }
    }
}
