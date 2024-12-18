using Application.v1.Cores.Themes.Commands.Create;
using Application.v1.Cores.Themes.Queries.GetAll;
using Application.v1.Cores.Users.Commands.Create;
using Application.v1.Cores.Users.Commands.Login;
using Application.v1.Cores.Users.Commands.Update;
using Application.v1.Cores.Users.Query.GetAll;
using Application.v1.Cores.Users.Query.GetById;
using Application.v1.Features.Quizzes.Commands.Create;
using Application.v1.Features.Quizzes.Commands.Update;
using Application.v1.Features.Quizzes.Query.GetAll;
using Application.v1.Features.Quizzes.Query.GetById;
using Application.v1.Features.Scores.Commands.Create;
using Application.v1.Features.Scores.Queries.GetAll;
using Application.v1.Features.Scores.Queries.GetById;
using Application.v1.Features.Scores.Queries.GetByQuizzId;
using Application.v1.Features.Scores.Queries.GetByUserId;
using Application.v1.Shared.Generic.Mapping;
using AutoMapper;
using Domain;
using Infrastructure.EF.DbEntities;

namespace Application.v1.Shared.Generic;

public class GenericHandler<TRepository>
    where TRepository : class
{
    protected readonly TRepository _TRepository;
    protected IMapper _mapper;

    public GenericHandler(TRepository tRepository)
    {
        _mapper = new MapperConfiguration(cfg =>
        {
            // USER
            cfg.AddProfile<UserMappingProfile>();

            // Quizz
            cfg.AddProfile<QuizzMappingProfile>();

            // Score
            cfg.AddProfile<ScoreMappingProfile>();

            // Theme
            cfg.AddProfile<ThemeMappingProfile>();

            // Question
            cfg.AddProfile<QuestionMappingProfile>();
        }).CreateMapper();
        _TRepository = tRepository;
    }
}