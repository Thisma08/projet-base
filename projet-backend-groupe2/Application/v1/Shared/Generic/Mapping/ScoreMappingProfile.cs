using Application.v1.Features.Scores.Queries.GetAll;
using Application.v1.Features.Scores.Queries.GetById;
using Application.v1.Features.Scores.Queries.GetByQuizzId;
using Application.v1.Features.Scores.Queries.GetByUserId;
using AutoMapper;
using Infrastructure.EF.DbEntities;

namespace Application.v1.Shared.Generic.Mapping;

public class ScoreMappingProfile : Profile
{
    public ScoreMappingProfile()
    {
        // Create
        // CreateMap<DbUser, User>();
        // CreateMap<DbQuizz, Quizz>();
        // CreateMap<DbTheme, Theme>();
        // CreateMap<Score, DbScore>()
        //     .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Quizz))
        //     .ForMember(dest => dest.QuizzId, opt => opt.MapFrom(src => src.User));

        // A trier            
        CreateMap<DbScore, ScoreGetAllOutput.Score>();
        CreateMap<DbScore, ScoreGetByIdOutput>();
        CreateMap<DbScore, ScoreGetByQuizzIdOutput.Score>();
        CreateMap<DbScore, ScoreGetByUserIdOutput.Score>();
    }
}