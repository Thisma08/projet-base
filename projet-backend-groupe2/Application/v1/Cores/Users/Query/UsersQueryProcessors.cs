using Application.v1.Cores.Users.Query.GetAll;
using Application.v1.Cores.Users.Query.GetById;

namespace Application.v1.Cores.Users.Query;

public class UsersQueryProcessors
{
    private readonly UsersGetAllHandler _getAllHandler;
    private readonly UsersGetByIdHandler _getByIdHandler;


    public UsersQueryProcessors(UsersGetAllHandler getAllHandler, UsersGetByIdHandler getByIdHandler)
    {
        _getAllHandler = getAllHandler;
        _getByIdHandler = getByIdHandler;
    }

    public List<UsersGetAllOutput.User> GetAll()
    {
        return _getAllHandler.Handle().Users;
    }

    public UsersGetByIdOutput GetById(int id)
    {
        return _getByIdHandler.Handle(id);
    }
}