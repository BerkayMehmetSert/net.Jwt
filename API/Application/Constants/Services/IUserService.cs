using API.Application.Constants.Requests.Users;
using API.Application.Constants.Responses.Users;

namespace API.Application.Constants.Services;

public interface IUserService
{
    void CreateUser(CreateUserRequest request);
    void UpdateUser(Guid id, UpdateUserRequest request);
    void DeleteUser(Guid id);
    UserResponse GetUserById(Guid id);
    List<UserResponse> GetAllUsers();
}
