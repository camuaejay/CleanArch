using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using CleanArchitecture.Infrastructure.Models.Requests.Users;
using CleanArchitecture.Infrastructure.Models.Responses.Users;
using CleanArchitecture.Services.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticateUserWebResponse>> AuthenticateUser([FromBody] AuthenticateUserWebRequest request)
        {
            var response = await this.userService.AuthenticateUser(request);

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<SaveUserWebResponse>> SaveUser([FromBody] SaveUserWebRequest request) 
        {
            var response = await this.userService.SaveUser(request);

            return Ok(response);
        }
    }
}