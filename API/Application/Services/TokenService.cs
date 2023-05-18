using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using API.Application.Constants.Config;
using API.Application.Constants.Repositories;
using API.Application.Constants.Requests.Tokens;
using API.Application.Constants.Responses.Tokens;
using API.Application.Constants.Services;
using API.Domain.Entities;
using API.Infrastructure.Exceptions.Types;
using API.Infrastructure.Utilities.Date;
using Microsoft.IdentityModel.Tokens;
using static API.Application.Constants.Messages.Users.UserMessage;

namespace API.Application.Services;

public class TokenService : ITokenService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly JwtConfig _jwtConfig;

    public TokenService(IUnitOfWork unitOfWork, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _jwtConfig = configuration.GetSection("JwtConfig").Get<JwtConfig>();
    }

    public TokenResponse GenerateToken(CreateTokenRequest request)
    {
        var user = _unitOfWork.UserRepository.Get(x => x.Email == request.Email);

        if (user is null) throw new NotFoundException(UserNotFound);
        CheckIfUserPasswordIsCorrect(user, request.Password);
        
        if (user.Role is null) throw new AuthenticationException(UserRoleNotFound);

        var token = GenerateJwtToken(user, CalculateDate.GetCurrentDate());

        return new TokenResponse
        {
            AccessToken = token,
            ExpireTime = CalculateDate.GetCurrentDate().AddMinutes(_jwtConfig.AccessTokenExpiration),
            Role = user.Role
        };
    }

    private string GenerateJwtToken(User user, DateTime dateTime)
    {
        var claims = GetClaim(user);

        var secret = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

        var jwtToken = new JwtSecurityToken(
            _jwtConfig.Issuer,
            _jwtConfig.Audience,
            claims,
            expires: dateTime.AddMinutes(_jwtConfig.AccessTokenExpiration),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret),
                SecurityAlgorithms.HmacSha256Signature));

        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        return token;
    }

    private static IEnumerable<Claim> GetClaim(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim("FullName", $"{user.FirstName} {user.LastName}"),
            new Claim("Role", user.Role),
            new Claim("Email", user.Email),
            new Claim("AccountId", user.Id.ToString())
        };

        return claims;
    }

    private void CheckIfUserPasswordIsCorrect(User user, string password)
    {
        if (user.Password != password) throw new BusinessException(UserPasswordIncorrect);
    }
}