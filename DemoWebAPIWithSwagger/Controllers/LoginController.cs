using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoWebAPIWithSwagger.Controllers
{
    
    #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class LoginController : ApiController
    {

        /// <summary>
        /// User login
        /// </summary>
        /// <remarks>
        /// Login to the application using the login credentials
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public HttpResponseMessage LoginService([FromBody] JObject loginJson)
        {
            string username = loginJson["username"].ToString();
            string password = loginJson["password"].ToString();
            if (username == "admin" && password == "admin")
            {
                var response = new
                {
                    Success = true,
                    Message = "Login successful!"
                };
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            else 
            {
                var response = new
                {
                    Success = false,
                    Message = "User login failed! Received invalid credentials."
                };
                return Request.CreateResponse(HttpStatusCode.Unauthorized, response);
            }
        }


    }
}
