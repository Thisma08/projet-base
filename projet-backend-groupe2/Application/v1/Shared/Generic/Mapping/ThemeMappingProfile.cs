using Application.v1.Cores.Themes.Commands.Create;
using Application.v1.Cores.Themes.Queries.GetAll;
using AutoMapper;
using Infrastructure.EF.DbEntities;

namespace Application.v1.Shared.Generic.Mapping;

public class ThemeMappingProfile : Profile
{
    public ThemeMappingProfile()
    {
        CreateMap<ThemeCreateCommand, DbTheme>();
        CreateMap<DbTheme, ThemeCreateOutput>();
        CreateMap<DbTheme, ThemeGetAllOutput.Theme>();       
    }
}