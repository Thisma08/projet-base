using Application.v1.Shared.Generic;
using Application.v1.Shared.Utils;
using Infrastructure.EF.interfaces;

namespace Application.v1.Cores.Users.Query.GetAll;

public class UsersGetAllHandler :
    GenericHandler<IUserRepository>,
    IQueryHandlerEmptyQuery<UsersGetAllOutput>
{
    public UsersGetAllHandler(IUserRepository tRepository) : base(tRepository)
    {
    }

    public UsersGetAllOutput Handle()
    {
        var output = new UsersGetAllOutput();

        foreach (var dbUser in _TRepository.FetchAll())
            output.Users.Add(_mapper.Map<UsersGetAllOutput.User>(dbUser));

        return output;
    }
}