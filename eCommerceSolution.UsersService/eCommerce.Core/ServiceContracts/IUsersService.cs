﻿using eCommerce.Core.DTO;

namespace eCommerce.Core.ServiceContracts;

public interface IUsersService
{
  /// <summary>
  /// Method to handle user login use case and returns an AuthenticationResponse
  /// object that contains status of login.
  /// </summary>
  /// <param name="loginRequest"></param>
  /// <returns></returns>
  Task<AuthenticationResponse?> Login(LoginRequest loginRequest);

  /// <summary>
  /// Method to handle user registration use case and returns an object of
  /// AuthenticationResponse type that represents status of user registration.
  /// object th
  /// </summary>
  /// <param name="registerRequest"></param>
  /// <returns></returns>
  Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
}