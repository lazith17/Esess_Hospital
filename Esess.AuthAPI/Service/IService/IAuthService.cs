﻿using Esess.AuthAPI.Models.DTO;

namespace Esess.AuthAPI.Service.IService;

public interface IAuthService
{
    Task<string> Register(RegistrationRequestDTO registrationRequestDTO);
    Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
    Task<bool> AssignRole(string email, string roleNames);

}
