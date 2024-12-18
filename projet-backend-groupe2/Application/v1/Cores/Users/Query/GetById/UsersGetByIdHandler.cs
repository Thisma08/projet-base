using Application.v1.Shared.Generic;
using Application.v1.Shared.Utils;
using Domain.exceptions;
using Infrastructure.EF.interfaces;

namespace Application.v1.Cores.Users.Query.GetById;

public class UsersGetByIdHandler :
    GenericHandler<IUserRepository>,
    IQueryHandler<int, UsersGetByIdOutput>
{
    public UsersGetByIdHandler(IUserRepository tRepository) : base(tRepository)
    {
    }

    public UsersGetByIdOutput Handle(int quizzId)
    {
        var dbUser = _TRepository.FetchById(quizzId);
        if (dbUser == null)
            throw new NotFoundObjectException(quizzId, "User");

        return _mapper.Map<UsersGetByIdOutput>(dbUser);
    }
}