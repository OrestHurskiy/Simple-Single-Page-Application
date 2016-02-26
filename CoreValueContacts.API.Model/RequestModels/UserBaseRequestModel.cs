using System;
using System.ComponentModel.DataAnnotations;

namespace CoreValueContacts.API.Model.RequestModels
{
    public abstract class UserBaseRequestModel
    {
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(200)]
        public string Email { get; set; }
    }
}
