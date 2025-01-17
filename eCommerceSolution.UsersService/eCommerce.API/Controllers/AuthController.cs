using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace eCommerce.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController:ControllerBase
  {
    private readonly IUsersService _usersService;

    public AuthController(IUsersService usersService)
    {
      _usersService = usersService;
    }

    //Endpoint for user registration use case.
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
      //Check for invalid register Request
      if(registerRequest == null)
      {
        return BadRequest("Invalid registration data.");
      }

      //Call the users service to handle registration
      AuthenticationResponse? response = await _usersService.Register(registerRequest);

      if (response == null || response.Success == false) {
        return BadRequest(response);
      }

      return Ok(response);
    }

    //Endpoint for user login use case.
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
      if (loginRequest == null) {
        return BadRequest("Invalid login request.");
      }

      AuthenticationResponse? response = await _usersService.Login(loginRequest);

      if(response == null || response.Success == false)
      {
        return Unauthorized(response);
      }

      return Ok(response);
    }
  }
}
