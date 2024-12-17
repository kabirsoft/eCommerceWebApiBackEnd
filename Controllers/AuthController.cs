using eCommerceWebApiBackEnd.Dto;
using eCommerceWebApiBackEnd.Services.AuthService;
using eCommerceWebApiBackEnd.Shared;
using Microsoft.AspNetCore.Mvc;


namespace eCommerceWebApiBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST api/auth/AddUser
        [HttpPost("AddUser")]        
        public async Task<ActionResult<ServiceResponse<int>>> AddUser(UserRegister newUser)
        {
            var response = await _authService.AddUser(
                new User
                {
                    Email = newUser.Email,
                },
                newUser.Password);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);

        }
    }
}
