using API.Services;
using Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService service;
        public UserController (UserService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async Task<ActionResult> AddUser(UserViewModel user)
        {
            await service.AddUser(user);
            return Ok();
        } 
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var result = await service.GetUsers();
            return StatusCode(StatusCodes.Status200OK, result);
            ;
        }
    }
}
