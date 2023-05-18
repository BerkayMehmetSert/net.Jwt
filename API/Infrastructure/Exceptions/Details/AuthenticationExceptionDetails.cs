using Microsoft.AspNetCore.Mvc;

namespace API.Infrastructure.Exceptions.Details;

public class AuthenticationExceptionDetails : ProblemDetails
{
    public AuthenticationExceptionDetails(string detail)
    {
        Title = "Authentication error";
        Detail = detail;
        Status = StatusCodes.Status401Unauthorized;
        Type = "https://example.com/probs/authentication";
    }
}