using Application.v1.Shared.Generic;
using Application.v1.Shared.Utils;
using Infrastructure.EF.DbEntities;
using Infrastructure.EF.interfaces;

namespace Application.v1.Cores.Themes.Commands.Create;

public class ThemeCreateHandler : GenericHandler<IThemeRepository>,
    ICommandsHandler<ThemeCreateCommand, ThemeCreateOutput>
{
    public ThemeCreateHandler(IThemeRepository tRepository) : base(tRepository)
    {
    }

    public ThemeCreateOutput Handle(ThemeCreateCommand command)
    {
        var dbTheme = _mapper.Map<DbTheme>(command);
        _TRepository.Create(dbTheme);
        return _mapper.Map<ThemeCreateOutput>(dbTheme);
    }
}