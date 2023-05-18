using API.Application.Constants.Requests.Users;
using API.Application.Constants.Responses.Users;
using API.Domain.Entities;
using AutoMapper;

namespace API.Application.Constants.Mapper;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<CreateUserRequest, User>();
        CreateMap<UpdateUserRequest, User>();
        CreateMap<User, UserResponse>();
    }
}