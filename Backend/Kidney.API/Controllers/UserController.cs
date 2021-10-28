using Kidney.Core.Entities;
using Kidney.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;


namespace Kidney.API.Controllers
{
    [Route("user/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public ActionResult Register([FromBody] User user)
        {
            if (!_userService.Register(user))
            {
                return BadRequest(user);
            }

            return Ok(user);
        }
    }
}
