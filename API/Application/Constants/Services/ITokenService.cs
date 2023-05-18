using API.Application.Constants.Requests.Tokens;
using API.Application.Constants.Responses.Tokens;

namespace API.Application.Constants.Services;

public interface ITokenService
{
    TokenResponse GenerateToken(CreateTokenRequest request);
}