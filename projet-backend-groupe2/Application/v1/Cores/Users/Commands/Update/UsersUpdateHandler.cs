using Application.v1.Shared.Generic;
using Application.v1.Shared.Utils;
using Infrastructure.EF.DbEntities;
using Infrastructure.EF.interfaces;

namespace Application.v1.Cores.Users.Commands.Update;

public class UsersUpdateHandler :
    GenericHandler<IUserRepository>,
    ICommandsHandler<UsersUpdateCommand, bool>
{
    public UsersUpdateHandler(IUserRepository tRepository) : base(tRepository)
    {
    }

    public bool Handle(UsersUpdateCommand command)
    {
        var dbUser = _mapper.Map<DbUser>(command);
        return _TRepository.Update(dbUser);
    }
}