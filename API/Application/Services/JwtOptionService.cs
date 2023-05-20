using API.Application.Constants.Repositories;
using API.Application.Constants.Services;
using API.Domain.Entities;
using API.Infrastructure.Exceptions.Types;

namespace API.Application.Services;

public class JwtOptionService : IJwtOptionService
{
    private readonly IUnitOfWork _unitOfWork;

    public JwtOptionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public JwtOption GetJwtOption(string name = "Default")
    {
        var jwtOption = _unitOfWork.JwtOptionRepository.Get(x => x.JwtName == name);
        
        return jwtOption ?? throw new InternalServerException("JwtOption not found");
    }
}