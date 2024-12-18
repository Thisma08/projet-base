using Application.v1.Shared.Generic;
using Application.v1.Shared.Utils;
using Infrastructure.EF.interfaces;

namespace Application.v1.Cores.Users.Commands.Delete;

public class UsersDeleteHandler :
    GenericHandler<IUserRepository>,
    ICommandsHandler<int, bool>
{
    public UsersDeleteHandler(IUserRepository tRepository) : base(tRepository)
    {
    }

    public bool Handle(int commands)
    {
        return _TRepository.Delete(commands);
    }
}