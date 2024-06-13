using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Esess.AuthAPI.Models.DTO;
using Esess.AuthAPI.Service.IService;

namespace Esess.AuthAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthAPIController : ControllerBase
{
    private readonly IAuthService _authService;
    protected ResponseDTO _responseDTO;

    public AuthAPIController(IAuthService authService)
    {
        _authService = authService;
        _responseDTO = new();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
    {
        var errorMessage = await _authService.Register(model);
        if (!string.IsNullOrEmpty(errorMessage))
        {
            _responseDTO.IsSuccess = false;
            _responseDTO.Message = errorMessage;
            return BadRequest(_responseDTO);
        }
        return Ok(_responseDTO);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
    {
        var loginResponse = await _authService.Login(model);
        if (loginResponse.User == null)
        {
            _responseDTO.IsSuccess = false;
            _responseDTO.Message = "Username or Password is incorrect";
            return BadRequest(_responseDTO);
        }
        _responseDTO.Result = loginResponse;
        return Ok(_responseDTO);
    }

    [HttpPost("AssignRole")]
    public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDTO model)
    {
        var assignRoleSuccessful = await _authService.AssignRole(model.Email, model.Role.ToUpper());
        if (!assignRoleSuccessful)
        {
            _responseDTO.IsSuccess = false;
            _responseDTO.Message = "Error Encountered";
            return BadRequest(_responseDTO);
        }
        return Ok(_responseDTO);
    }
}