﻿using Microsoft.AspNetCore.Mvc;

namespace API.Infrastructure.Exceptions.Details;

public class NotFoundExceptionDetails : ProblemDetails
{
    public NotFoundExceptionDetails(string detail)
    {
        Title = "Not found error";
        Detail = detail;
        Status = StatusCodes.Status404NotFound;
        Type = "https://example.com/probs/not-found";
    }
}