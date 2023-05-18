using Microsoft.AspNetCore.Mvc;

namespace API.Infrastructure.Exceptions.Details;

public class InternalServerErrorExceptionDetails : ProblemDetails
{
    public InternalServerErrorExceptionDetails(string detail)
    {
        Title = "Internal server error";
        Detail = detail;
        Status = StatusCodes.Status500InternalServerError;
        Type = "https://example.com/probs/internal-server-error";
    }
}