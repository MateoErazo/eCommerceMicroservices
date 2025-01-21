using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

internal class UsersService : IUsersService
{
  private readonly IUsersRepository _usersRepository;
  private readonly IMapper _mapper;

  public UsersService(IUsersRepository usersRepository, IMapper mapper)
  {
    _usersRepository = usersRepository;
    this._mapper = mapper;
  }
  public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
  {
    ApplicationUser user = await _usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

    if (user == null) { return null; }

    return _mapper.Map<AuthenticationResponse>(user) 
      with {Success = true, Token = "Token"};
  }

  public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
  {
    //Create a new ApplicationUser object from registerRequest.
    ApplicationUser user = _mapper.Map<ApplicationUser>(registerRequest);

    ApplicationUser? userRegistered = await _usersRepository.AddUser(user);

    if (userRegistered == null) { return null; }

    //Return success response.
    return _mapper.Map<AuthenticationResponse>(userRegistered)
      with {Success = true, Token = "Token"};
  }
}
