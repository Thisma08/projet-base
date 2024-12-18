using Application.v1.Features.Questions.Commands.Update;
using AutoMapper;
using Infrastructure.EF.DbEntities;

namespace Application.v1.Shared.Generic.Mapping;

public class QuestionMappingProfile : Profile
{
    public QuestionMappingProfile()
    {
        CreateMap<QuestionUpdateCommand, DbQuestion>();
    }
}