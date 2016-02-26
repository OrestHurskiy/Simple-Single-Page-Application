using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CoreValueContacts.API.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class InvalidModelStateFilterAttribute : ActionFilterAttribute
    {
        public string ParameterName { get; private set; }

        public InvalidModelStateFilterAttribute(string parametername)
        {
            if(string.IsNullOrEmpty(parametername))
            {
                throw new ArgumentNullException("parametrname");
            }

            ParameterName = parametername;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            object parameterValue;

            if(actionContext.ActionArguments.TryGetValue(ParameterName, out parameterValue))
            {
                if(parameterValue == null)
                {
                    actionContext.ModelState.AddModelError(ParameterName, FormatErrorMessage(ParameterName));
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
                }
            }
        }

        private string FormatErrorMessage(string parameterName)
        {
            return string.Format("The {0} cannot be null.", parameterName);
        }
    }
}
