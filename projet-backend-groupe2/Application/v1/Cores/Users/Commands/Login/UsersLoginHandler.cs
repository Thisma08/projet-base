using Application.v1.Shared.Generic;
using Application.v1.Shared.Utils;
using Domain;
using Domain.exceptions;
using Domain.models;
using Infrastructure.EF.interfaces;

namespace Application.v1.Cores.Users.Commands.Login;

public class UsersLoginHandler : GenericHandler<IUserRepository>, ICommandsHandler<UsersLoginCommand, UsersLoginOutput>
{
    public UsersLoginHandler(IUserRepository tRepository) : base(tRepository)
    {
    }

    public UsersLoginOutput Handle(UsersLoginCommand query)
    {
        var dbUser = _TRepository.FetchByName(query.Username);

        if (dbUser == null) throw new NotGoodLoginException("Login is incorrect");

        User user = new User(dbUser.Username, dbUser.Password);

        if (user.Login(query.Password))
            return _mapper.Map<UsersLoginOutput>(dbUser);

        throw new NotGoodLoginException("Passwords do not match");
    }
}