using CoreValueContacts.API.Model.RequestModels.Interfaces;
using System;

namespace CoreValueContacts.API.Model.RequestModels
{
    public class CustomerRequestModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Mail { get; set; }

        public string Phone { get; set; }
    }
}
