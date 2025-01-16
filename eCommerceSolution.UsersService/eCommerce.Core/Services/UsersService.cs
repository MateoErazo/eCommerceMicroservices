using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

internal class UsersService : IUsersService
{
  private readonly IUsersRepository _usersRepository;

  public UsersService(IUsersRepository usersRepository)
  {
    _usersRepository = usersRepository;
  }
  public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
  {
    ApplicationUser user = await _usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

    if (user == null) { return null; }

    return new AuthenticationResponse(
      user.UserId,
      user.Email,
      user.PersonName,
      user.Gender,
      "Token",
      Success:true);
  }

  public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
  {
    //Create a new ApplicationUser object from registerRequest.
    ApplicationUser user = new ApplicationUser()
    {
      PersonName = registerRequest.PersonName,
      Email = registerRequest.Email,
      Password = registerRequest.Password,
      Gender = registerRequest.Gender.ToString()
    };

    ApplicationUser? userRegistered = await _usersRepository.AddUser(user);

    if (userRegistered == null) { return null; }

    //Return success response.
    return new AuthenticationResponse(
      userRegistered.UserId,
      userRegistered.Email,
      userRegistered.PersonName,
      userRegistered.Gender,
      "Token",
      Success: true);
  }
}
