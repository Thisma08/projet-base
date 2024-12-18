using Application.v1.Shared.Generic;
using Application.v1.Shared.Utils;
using Domain;
using Domain.models;
using Infrastructure.EF.DbEntities;
using Infrastructure.EF.interfaces;

namespace Application.v1.Cores.Users.Commands.Create;

public class UsersCreateHandler :
    GenericHandler<IUserRepository>,
    ICommandsHandler<UsersCreateCommand, UsersCreateOutput>
{
    public UsersCreateHandler(IUserRepository userRepository) : base(userRepository)
    {
    }

    public UsersCreateOutput Handle(UsersCreateCommand command)
    {
        User user = User.Register(command.Username, command.Password, command.Email, command.Role);

        var dbUser = _mapper.Map<DbUser>(user);

        dbUser.Password = user.GetHashedPassword(); // HashedPassword != Password, so I have to write manually
        
        _TRepository.Create(dbUser);

        return _mapper.Map<UsersCreateOutput>(dbUser);
    }
}