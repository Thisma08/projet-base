using Application.v1.Cores.Users.Commands.Create;
using Application.v1.Cores.Users.Commands.Update;
using Application.v1.Cores.Users.Query.GetAll;
using Application.v1.Cores.Users.Query.GetById;
using Application.v1.Features.Quizzes.Query.GetAll;
using AutoMapper;
using Domain;
using Domain.models;
using Infrastructure.EF.DbEntities;

namespace Application.v1.Shared.Generic.Mapping;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        // Commands
        CreateMap<User, DbUser>();
        CreateMap<DbUser, UsersCreateOutput>();
        CreateMap<UsersUpdateCommand, DbUser>();
        CreateMap<DbUser, QuizzesGetAllOutput.Quizz.Users>();
        // Query
        CreateMap<DbUser, UsersGetAllOutput.User>();
        CreateMap<DbUser, UsersGetByIdOutput>();
    }
}