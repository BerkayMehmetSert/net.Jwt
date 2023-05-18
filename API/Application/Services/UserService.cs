using API.Application.Constants.Repositories;
using API.Application.Constants.Requests.Users;
using API.Application.Constants.Responses.Users;
using API.Application.Constants.Services;
using API.Domain.Entities;
using API.Infrastructure.Exceptions.Types;
using AutoMapper;
using static API.Application.Constants.Messages.Users.UserMessage;

namespace API.Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public void CreateUser(CreateUserRequest request)
    {
        var user = _mapper.Map<User>(request);
        user.Role = "User";

        _unitOfWork.UserRepository.Create(user);
        _unitOfWork.SaveChanges();
    }

    public void UpdateUser(Guid id, UpdateUserRequest request)
    {
        var user = GetUser(id);

        var updatedUser = _mapper.Map(request, user);

        _unitOfWork.UserRepository.Update(updatedUser);
        _unitOfWork.SaveChanges();
    }

    public void DeleteUser(Guid id)
    {
        var user = GetUser(id);

        _unitOfWork.UserRepository.Delete(user);
        _unitOfWork.SaveChanges();
    }

    public UserResponse GetUserById(Guid id)
    {
        var user = GetUser(id);

        return _mapper.Map<UserResponse>(user);
    }

    public List<UserResponse> GetAllUsers()
    {
        var users = _unitOfWork.UserRepository.GetAll();

        return users is not null
            ? _mapper.Map<List<UserResponse>>(users)
            : throw new NotFoundException(UsersNotFound);
    }

    private User GetUser(Guid id)
    {
        var user = _unitOfWork.UserRepository.Get(x => x.Id == id);

        return user ?? throw new NotFoundException(UserNotFound);
    }
}