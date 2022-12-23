using AutoMapper;
using FaceCheck.Entity.Models;
using FaceCheck.Repository;
using FaceCheck.Services.Abstract;
using FaceCheck.Services.Models;
using FaceCheck.Shared.Exceptions;
using FaceCheck.Shared.ResultCodes;

namespace FaceCheck.Services.Implementation;

public class UserService : IUserService
{
    private readonly IRepository<User> usersRepository;
    private readonly IMapper mapper;
    public UserService(IRepository<User> usersRepository, IMapper mapper)
    {
        this.usersRepository = usersRepository;
        this.mapper = mapper;
    }

    public void DeleteUser(Guid id)
    {
        var userToDelete = usersRepository.GetById(id);
        if (userToDelete == null)
        {
             throw new LogicException(ResultCode.USER_NOT_FOUND);
        }

        usersRepository.Delete(userToDelete);
    }

    public UserModel GetUser(Guid id)
    {
        var user = usersRepository.GetById(id);
        if (user == null)
        {
            throw new LogicException(ResultCode.USER_NOT_FOUND);
        }
        return mapper.Map<UserModel>(user);
    }

    public PageModel<UserPreviewModel> GetUsers(int limit = 20, int offset = 0)
    {
         var users = usersRepository.GetAll(); //query created
        int totalCount = users.Count();
        var chunk = users.OrderBy(x => x.Email).Skip(offset).Take(limit); //query updated IQueruable<User>

        return new PageModel<UserPreviewModel>()
        {
            Items = chunk.Select(x => mapper.Map<UserPreviewModel>(x)),
            TotalCount = totalCount
        };
    }

    public UserModel UpdateUser(Guid id, UpdateUserModel user)
    {
        var existingUser = usersRepository.GetById(id);
        if (existingUser == null)
        {
            throw new LogicException(ResultCode.USER_NOT_FOUND);
        }

        existingUser.Name = user.Name;


        existingUser = usersRepository.Save(existingUser);
        return mapper.Map<UserModel>(existingUser);
    }
   
}