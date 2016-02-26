using CoreValueContacts.API.Model.RequestModels;
using CoreValueContacts.Domain.Infrastructure;
using CoreValueContacts.Services.Services;
using CoreValueContacts.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CoreValueContacts.API.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IMembershipService _membershipService;
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IMembershipService membershipService, IUnitOfWork unitOfWork)
        {
            _membershipService = membershipService;
            _unitOfWork = unitOfWork;
        }

        [AllowAnonymous]
        [Route("authenticate")]
        [HttpPost]
        public HttpResponseMessage Login(LoginRequestModel user)
        {
            HttpResponseMessage response = null;

            MembershipContext _userContext = _membershipService.ValidateUser(user.Username, user.Password);

            if(_userContext.User != null)
            {
                response = Request.CreateResponse(System.Net.HttpStatusCode.OK, new { success = true });
            }
            else
            {
                response = Request.CreateResponse(System.Net.HttpStatusCode.OK, new { success = false });
            }

            return response;
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public HttpResponseMessage Register(RegistrationRequestModel user)
        {
            HttpResponseMessage response = null;

            var _user = _membershipService.CreateUser(user.Username, user.Email, user.Password, new string[] { "User" });

            if(_user != null)
            {
                response = Request.CreateResponse(System.Net.HttpStatusCode.OK, new { success = true });
            }
            else
            {
                response = Request.CreateResponse(System.Net.HttpStatusCode.OK, new { success = false });
            }

            return response;
        }
    }
}
