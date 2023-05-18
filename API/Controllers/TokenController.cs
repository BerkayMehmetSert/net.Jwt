using API.Application.Constants.Requests.Tokens;
using API.Application.Constants.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TokenController : ControllerBase
{
    private readonly ITokenService _service;

    public TokenController(ITokenService service)
    {
        _service = service;
    }
    
    [HttpPost]
    public IActionResult CreateToken([FromBody] CreateTokenRequest request)
    {
        var token = _service.GenerateToken(request);
        return Ok(new
        {
            Success = true,
            Token = token
        });
    }
}