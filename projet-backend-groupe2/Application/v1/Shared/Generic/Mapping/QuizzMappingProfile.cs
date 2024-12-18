using Application.v1.Cores.Users.Commands.Login;
using Application.v1.Features.Quizzes.Commands.Create;
using Application.v1.Features.Quizzes.Commands.Update;
using Application.v1.Features.Quizzes.Query.GetAll;
using Application.v1.Features.Quizzes.Query.GetById;
using AutoMapper;
using Infrastructure.EF.DbEntities;

namespace Application.v1.Shared.Generic.Mapping;

public class QuizzMappingProfile : Profile
{
    public QuizzMappingProfile()
    {
        // Commands
        CreateMap<DbUser, UsersLoginOutput>();
        // TODO : a faire
        CreateMap<QuizzesUpdateCommand.Users, DbUser>();
        // CreateMap<QuizzesUpdateCommand.Question, DbQuestion>();
        CreateMap<QuizzesUpdateCommand.Themes, DbTheme>();
        CreateMap<QuizzesUpdateCommand, DbQuizz>()
            .ForMember(dest => dest.Questions, opt => opt.Ignore())
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            .ForMember(dest => dest.Theme, opt => opt.MapFrom(src => src.Theme));

        CreateMap<QuizzesCreateCommand.Users, DbUser>();
        CreateMap<QuizzesCreateCommand.Question, DbQuestion>();
        CreateMap<QuizzesCreateCommand.Themes, DbTheme>();
        CreateMap<QuizzesCreateCommand, DbQuizz>()
            .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions))
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            .ForMember(dest => dest.Theme, opt => opt.MapFrom(src => src.Theme));

        CreateMap<DbUser, QuizzesCreateOutput.Users>();
        CreateMap<DbQuestion, QuizzesCreateOutput.Question>();
        CreateMap<DbTheme, QuizzesCreateOutput.Themes>();
        CreateMap<DbQuizz, QuizzesCreateOutput>()
            .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions))
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            .ForMember(dest => dest.Theme, opt => opt.MapFrom(src => src.Theme));
        // Query
        CreateMap<DbQuestion, QuizzesGetAllOutput.Quizz.Question>();
        CreateMap<DbTheme, QuizzesGetAllOutput.Quizz.Themes>();
        CreateMap<DbQuizz, QuizzesGetAllOutput.Quizz>()
            .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions))
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            .ForMember(dest => dest.Theme, opt => opt.MapFrom(src => src.Theme));
        CreateMap<DbUser, QuizzesGetByIdOutput.Users>();
        CreateMap<DbQuestion, QuizzesGetByIdOutput.Question>();
        CreateMap<DbTheme, QuizzesGetByIdOutput.Themes>();
        CreateMap<DbQuizz, QuizzesGetByIdOutput>()
            .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions))
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            .ForMember(dest => dest.Theme, opt => opt.MapFrom(src => src.Theme));
    }
}