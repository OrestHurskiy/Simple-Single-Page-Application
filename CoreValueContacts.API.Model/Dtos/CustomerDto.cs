using WebApiDoodle.Net.Http.Client.Model;
using System;
using System.Collections.Generic;

namespace CoreValueContacts.API.Model.Dtos
{
    public class CustomerDto : IDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Mail { get; set; }

        public string Phone { get; set; }
        
        public IList<ProjectDto> Projects { get; set; }
    }
}
