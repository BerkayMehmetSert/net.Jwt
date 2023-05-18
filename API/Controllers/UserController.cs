using API.Application.Constants.Requests.Users;
using API.Application.Constants.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static API.Application.Constants.Messages.Users.UserMessage;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] CreateUserRequest request)
    {
        _service.CreateUser(request);
        return Ok(new
        {
            Success = true,
            Message = UserCreated
        });
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserRequest request)
    {
        _service.UpdateUser(id, request);

        return Ok(new
        {
            Success = true,
            Message = UserUpdated
        });
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteUser([FromRoute] Guid id)
    {
        _service.DeleteUser(id);

        return Ok(new
        {
            Success = true,
            Message = UserDeleted
        });
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,User")]
    public IActionResult GetUserById([FromRoute] Guid id)
    {
        var user = _service.GetUserById(id);

        return Ok(new
        {
            Success = true,
            Messages = UserRetrieved,
            Data = user
        });
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult GetAllUsers()
    {
        var users = _service.GetAllUsers();

        return Ok(new
        {
            Success = true,
            Messages = UserRetrieved,
            Data = users
        });
    }
}