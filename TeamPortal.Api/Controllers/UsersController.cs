using Microsoft.AspNetCore.Mvc;
using TeamPortal.Api.Dtos;
using TeamPortal.Api.Services;

namespace TeamPortal.Api.Controller;

[ApiController]
[Route("api/[Controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
    {
        var result = await _userService.CreateUserAsync(userDto);
        return CreatedAtAction(nameof(CreateUser), new { id = result.Id }, result);
    }
}