using Application.v1.Cores.Users.Commands.Create;
using Application.v1.Cores.Users.Commands.Delete;
using Application.v1.Cores.Users.Commands.Login;
using Application.v1.Cores.Users.Commands.Update;

namespace Application.v1.Cores.Users.Commands;

public class UsersCommandsProcessors
{
    private readonly UsersCreateHandler _createHandler;
    private readonly UsersDeleteHandler _deleteHandler;
    private readonly UsersUpdateHandler _updateHandler;
    private readonly UsersLoginHandler _usersLoginHandler;

    public UsersCommandsProcessors(UsersCreateHandler createHandler, UsersDeleteHandler deleteHandler,
        UsersUpdateHandler updateHandler, UsersLoginHandler usersLoginHandler)
    {
        _createHandler = createHandler;
        _deleteHandler = deleteHandler;
        _updateHandler = updateHandler;
        _usersLoginHandler = usersLoginHandler;
    }

    public UsersCreateOutput Create(UsersCreateCommand command)
    {
        return _createHandler.Handle(command);
    }

    public bool Delete(int query)
    {
        return _deleteHandler.Handle(query);
    }

    public bool Update(UsersUpdateCommand command)
    {
        return _updateHandler.Handle(command);
    }

    public UsersLoginOutput Login(UsersLoginCommand command)
    {
        return _usersLoginHandler.Handle(command);
    }
}