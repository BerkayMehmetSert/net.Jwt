﻿using System.Text.Json;
using API.Infrastructure.Exceptions.Details;
using API.Infrastructure.Exceptions.Types;

namespace API.Infrastructure.Exceptions.Handlers;

public class HttpExceptionHandler : ExceptionHandler
{
    public HttpResponse? Response { get; set; }
    protected override Task HandleException(BusinessException businessException)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        var detail = new BusinessExceptionDetails(businessException.Message);
        var result = JsonSerializer.Serialize(detail);
        return Response.WriteAsync(result);
    }

    protected override Task HandleException(NotFoundException notFoundException)
    {
        Response.StatusCode = StatusCodes.Status404NotFound;
        var detail = new NotFoundExceptionDetails(notFoundException.Message);
        var result = JsonSerializer.Serialize(detail);
        return Response.WriteAsync(result);
    }

    protected override Task HandleException(ValidationException validationException)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        var detail = new ValidationExceptionDetails(validationException.Errors);
        var result = JsonSerializer.Serialize(detail); 
       return Response.WriteAsync(result);
    }

    protected override async Task HandleException(AuthorizationException authorizationException)
    {
        Response.StatusCode = StatusCodes.Status401Unauthorized;
        var detail = new AuthenticationExceptionDetails(authorizationException.Message);
        var result = JsonSerializer.Serialize(detail);
        await Response.WriteAsync(result);
    }

    protected override Task HandleException(Exception exception)
    {
        Response.StatusCode = StatusCodes.Status500InternalServerError;
        var detail = new InternalServerErrorExceptionDetails(exception.Message);
        var result = JsonSerializer.Serialize(detail);
        return Response.WriteAsync(result);
    }
}