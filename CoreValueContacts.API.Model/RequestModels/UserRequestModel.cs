using System;
using System.ComponentModel.DataAnnotations;

namespace CoreValueContacts.API.Model.RequestModels
{
    public class UserRequestModel : UserBaseRequestModel
    {
        [Required]
        [StringLength(30, MinimumLength = 8)]
        public string Password { get; set; }

        [MinLength(1)]
        public string[] Roles { get; set; }
    }
}
