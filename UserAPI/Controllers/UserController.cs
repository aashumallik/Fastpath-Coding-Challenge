using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserAPI.Service;
using System.Threading.Tasks;

namespace UserAPI.Controllers
{

    //localhost:12345/api/User/getAllUsersAsync
    public class UserController : ApiController
    {
        UserService userService;
        public UserController()
        {
            userService = new UserService();
        }

        public async Task<HttpResponseMessage> getAllUsersAsync()
        {
            try
            {
                var users = await userService.GetUsersAsync();
                return Request.CreateResponse(HttpStatusCode.OK, users);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
    }
}
